using ScottPlot;
using ScottPlot.TickGenerators.Financial;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Measurement_Kits
{
    public partial class Form_Transport : Form
    {
        private Form_Menu Form_Menu;
        
        private List<double> List_Index = new List<double>();
        private List<double> List_Temperature = new List<double>();
        private List<double> List_Resistance = new List<double>();        
        private Keithley2000 _keithley;
        private LakeShore335 _lakeshore;
        private CancellationTokenSource _cts;
        private bool _isRunning = false;
        private int _timeStepMs; // інтервал у мс (можеш змінювати прямо з форми)
        private Queue<(DateTime Time, double Temp)> tempHistory = new Queue<(DateTime, double)>();
        private int measureCounter = 0; // лічильник вимірів для середнього
        public Form_Transport(Form_Menu menu)
        {
            InitializeComponent();
            Form_Menu = menu;
            GlobalExitHelper.AttachGlobalExit(this);

        }
        private Random _rnd = new Random();
        private ScottPlot.WinForms.FormsPlot Plot1;
        private ScottPlot.WinForms.FormsPlot Plot2;
        
        private ScottPlot.Plottables.DataStreamerXY DataLoggerPlot1;
        private ScottPlot.Plottables.DataStreamerXY DataLoggerPlot2;
        

        private void SetupPlots() 
        {
            Plot1 = new ScottPlot.WinForms.FormsPlot();
            
            Plot1.Dock = DockStyle.Fill;
            panel1.Controls.Add(Plot1);
            Plot2 = new ScottPlot.WinForms.FormsPlot();
            Plot2.Dock = DockStyle.Fill;
            panel2.Controls.Add(Plot2);
            var x = Plot1.Plot;

            DataLoggerPlot1 = Plot1.Plot.Add.DataStreamerXY(10000);            
            Plot1.Plot.XLabel("T (K)");
            Plot1.Plot.YLabel("R (Ω)");
            
            

            DataLoggerPlot2 = Plot2.Plot.Add.DataStreamerXY(10000);
            Plot2.Plot.XLabel("Index");
            Plot2.Plot.YLabel("T (K)");
           
            
            
            
            DataLoggerPlot1.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Red);
            DataLoggerPlot2.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Blue);
            DataLoggerPlot1.LineWidth = 0;
            DataLoggerPlot1.MarkerSize = 10;
            DataLoggerPlot1.MarkerShape = MarkerShape.FilledDiamond;
            DataLoggerPlot2.LineWidth = 0;
            DataLoggerPlot2.MarkerSize = 10;
            DataLoggerPlot2.MarkerShape = MarkerShape.FilledDiamond;
            DataLoggerPlot1.ManageAxisLimits = true;
            DataLoggerPlot2.ManageAxisLimits = true;

            label_Plot1_Coordinate.Text = $"X={0}, Y={0}";
            label_Plot2_Coordinate.Text = $"X={0}, Y={0}";
            Plot1.MouseDown += (s, e) =>
            {
                Pixel mousePixel = new Pixel(e.X, e.Y);
                Coordinates mouseCoordinates = Plot1.Plot.GetCoordinates(mousePixel);
                label_Plot1_Coordinate.Text = $"X={mouseCoordinates.X:N3}, Y={mouseCoordinates.Y:N3} (mouse down)";
            };
            Plot2.MouseDown += (s, e) =>
            {
                Pixel mousePixel = new Pixel(e.X, e.Y);
                Coordinates mouseCoordinates = Plot2.Plot.GetCoordinates(mousePixel);
                label_Plot2_Coordinate.Text = $"X={mouseCoordinates.X:N3}, Y={mouseCoordinates.Y:N3} (mouse down)";
            };            
            button_Plot2Scale.Text = "AutoS";
            button_Plot2Scale.Text = "AutoS";
            Plot1.Refresh();
            Plot2.Refresh();
        }
        private void CreatCOM() 
        {
            try
            {
                comboBox1.Items.Clear();
                string[] ports = SerialPort.GetPortNames(); // Отримати список портів

                comboBox1.Items.AddRange(ports);
                comboBox2.Items.AddRange(ports);
                if (ports.Length > 0)
                {
                    comboBox1.SelectedIndex = 1; // вибрати перший порт
                    comboBox2.SelectedIndex = 2;
                }
                else
                    comboBox1.Text = "Немає портів";
            }
            catch (Exception)
            {                
                
            }
            
        }

        
        private void Form_Transport_SizeChanged(object sender, EventArgs e)
        {
            panel1.Height = this.Height - Plot1Sizedifference_hight;
            //panel2.Height = this.Height - Plot2Sizedifference_hight;
            panel1.Width = this.Width - Plot1Sizedifference_widht;
            panel2.Width = this.Width - Plot2Sizedifference_widht;
        }
        private int Plot2Sizedifference_widht, Plot1Sizedifference_widht;
        int Plot1Sizedifference_hight, Plot2Sizedifference_hight;
        private void Transport_Load(object sender, EventArgs e)
        {
            
            _timeStepMs = (int) numericUpDown1.Value;
            SetupPlots();
            CreatCOM();
            Plot1Sizedifference_widht = this.Size.Width - panel1.Width;
            Plot2Sizedifference_widht = this.Size.Width - panel1.Width;

            Plot1Sizedifference_hight = this.Size.Height-panel1.Height;
            Plot2Sizedifference_hight = this.Size.Height-panel2.Height;
            Form_Transport_SizeChanged(null, null);
        }
        private void button_ConnectToMultimetr_Click(object sender, EventArgs e)
        {
            string portName = comboBox1.Text;            
            _keithley = new Keithley2000();
            bool status = _keithley.Connect(portName);
            if (status)
            {
                button_ConnectToMultimetr.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                button_ConnectToMultimetr.BackColor = System.Drawing.Color.Orange;
            }
        }
        private void button_ConnectToLakeShore_Click(object sender, EventArgs e)
        {
            
            string portName = comboBox2.Text;            
            _lakeshore = new LakeShore335();
            bool status = _lakeshore.Connect(portName);
            if (status)
            {
                button_ConnectToLakeShore.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                button_ConnectToLakeShore.BackColor = System.Drawing.Color.Orange;
            }
        }

        private void button_Menu_Click(object sender, EventArgs e)
        {
            GlobalExitHelper.SwitchTo(this, Form_Menu);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _timeStepMs = (int)numericUpDown1.Value;
        }       

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isRunning)
                {
                    // Запуск
                    _cts = new CancellationTokenSource();
                    _isRunning = true;
                    button3.Text = "Pause";                    
                    await Task.Run(() => MeasurementLoop(_cts.Token,check_channel_A.Checked, check_channel_B.Checked, checkBox_Get_K.Checked, checkBox_Get_Sensor.Checked, checkBox_Wtite_time_in_file.Checked));
                }
                else
                {
                    // Пауза
                    _cts.Cancel();
                    _isRunning = false;
                    button3.Text = "Start";
                }
            }
            catch (TaskCanceledException)
            {
                // Це нормальне завершення, нічого не робимо
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка в циклі: {ex.Message}");
                var x = ex.Message;                
            }

        }
        private async Task MeasurementLoop(CancellationToken token, bool channel_A,bool channel_B,bool Get_K,bool Get_Sensor,bool read_time = false)
        {
            string filePath = label_path.Text;
            string name_channel = "A";
            if (channel_B)
            {
                name_channel = "B";
            }
            // якщо файл новий – додаємо заголовки
            if (!File.Exists(filePath))
            {
                
            }
            //File.AppendAllText(filePath, "Time\tResistance\tTemperature\n");
            if (read_time)
            {               
                File.AppendAllText(filePath, "Time\tTemperature\tResistance\r\n");
            }
            else
            {
                File.AppendAllText(filePath, "Temperature\tResistance\r\n");
            }
            

            var sw = new Stopwatch();
            sw.Start();
            long lastTick = sw.ElapsedTicks;
            _keithley.Set_INIT_COUNT_ON();
            
            while (!token.IsCancellationRequested)
            {
                // Обчислюємо час, який пройшов
                long currentTick = sw.ElapsedMilliseconds;
                double elapsedMicroSec = (long)(currentTick - lastTick);

                if (elapsedMicroSec >= _timeStepMs) // наприклад, 50 мкс
                {
                    lastTick += _timeStepMs;
                    var time = DateTime.Now.ToString("HH:mm:ss.fff");

                    //  зчитування даних з приладів
                    double resistance = _keithley.Get_FETCh();
                    double temperature = 0;
                    if (Get_K) 
                    {
                        temperature = _lakeshore.GetTemperature_K(name_channel);

                    }
                    if (Get_Sensor)
                    {
                        temperature = _lakeshore.GetSensor(name_channel);
                    }
                    
                    AddTemperature(temperature);
                    // Запис у файл
                    //string line = $"{DateTime.Now:HH:mm:ss.fff}\t{temp:E8}\t{rate:E8}\n";
                    string line;
                    if (read_time)
                    {
                        line = $"{time}\t{temperature:E8}\t{resistance:E8}\r\n";
                                  
                    }
                    else
                    {
                        line = $"{temperature:E8}\t{resistance:E8}\r\n";
                    }                    

                    File.AppendAllText(filePath, line);                    
                    measureCounter++;                    
                    if (measureCounter % 3 == 0) // кожні 3 цикли
                    {
                        double TempSpeed = ComputeTemperatureSlope();                        
                        // Оновлюємо label у GUI-потоці
                        this.Invoke(new Action(() =>
                        {
                            label_TempNow.Text = $"P{temperature:f}K";
                            label_TempSpeed.Text = $"Temp Speed = {TempSpeed:f3} K/min";
                        }));

                    }
                    // Оновлення графіка на формі
                    this.Invoke(new Action(() =>
                    {                        
                        DataLoggerPlot1.Add(temperature, resistance);
                        DataLoggerPlot2.Add(measureCounter, temperature);
                        Plot1.Refresh();
                        Plot2.Refresh();                       
                    }));
                }
                else
                {
                    int delay = (int)(_timeStepMs - elapsedMicroSec);
                    if (delay > 1)
                    {
                        await Task.Delay(delay);
                    }
                    else
                    {
                        await Task.Yield();
                    }
                }
                // Коротка пауза, щоб не “з’їдати” CPU
                await Task.Yield();
            }

        }
       
        private void AddTemperature(double temp)
        {
            var now = DateTime.Now;
            tempHistory.Enqueue((now, temp));
            if (tempHistory.Count > 5)
                tempHistory.Dequeue();
        }
        public double ComputeTemperatureSlope()
        {
            if (tempHistory.Count < 2)
                return 0;

            var points = tempHistory.ToArray();
            int N = points.Length;

            // Робимо час у секундах відносно першого
            double t0 = points[0].Time.ToOADate();
            double[] t = points.Select(p => (p.Time.ToOADate() - t0) * 24 * 60).ToArray(); // minute
            double[] T = points.Select(p => p.Temp).ToArray();

            double sumT = T.Sum(); // SUM temp 
            double sumt = t.Sum(); //  SUM time normolize
            double sumtT = t.Zip(T, (x, y) => x * y).Sum(); //SUM  time*Temp
            double sumt2 = t.Select(x => x * x).Sum(); // SUM t*t

            double a = (N * sumtT - sumt * sumT) / (N * sumt2 - sumt * sumt);
            return a; // °K/minute
        }
        private void label_path_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.FileName = "data.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    label_path.Text = saveFileDialog.FileName;
                }
            }
        }

        private void label_path_Click_1(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.FileName = "data.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    label_path.Text = saveFileDialog.FileName;
                }
            }
        }

        

        

        private void button_Plot1Clear_Click(object sender, EventArgs e)
        {
            // DataStreamerXY does not have a Clear() method. To clear the plot, remove and re-add the DataStreamerXY.
            Plot1.Plot.Remove(DataLoggerPlot1);
            DataLoggerPlot1 = Plot1.Plot.Add.DataStreamerXY(10000);
            DataLoggerPlot1.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Red);
            DataLoggerPlot1.LineWidth = 0;
            DataLoggerPlot1.MarkerSize = 10;
            DataLoggerPlot1.MarkerShape = MarkerShape.FilledDiamond;
            DataLoggerPlot1.ManageAxisLimits = true;
            Plot1.Refresh();
        }

        private void button_Plot2Clear_Click(object sender, EventArgs e)
        {
            // DataStreamerXY does not have a Clear() method. To clear the plot, remove and re-add the DataStreamerXY.
            Plot2.Plot.Remove(DataLoggerPlot2);
            DataLoggerPlot2 = Plot2.Plot.Add.DataStreamerXY(10000);
            DataLoggerPlot2.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Blue);
            DataLoggerPlot2.LineWidth = 0;
            DataLoggerPlot2.MarkerSize = 10;
            DataLoggerPlot2.MarkerShape = MarkerShape.FilledDiamond;
            DataLoggerPlot2.ManageAxisLimits = true;
            Plot2.Refresh();
        }
        

        private void button_Plot1Scale_Click(object sender, EventArgs e)
        {
            DataLoggerPlot1.ManageAxisLimits = !DataLoggerPlot1.ManageAxisLimits;
            Plot1.Refresh();
            if (DataLoggerPlot1.ManageAxisLimits)
            {
                button_Plot1Scale.Text = "AutoS";
            }
            else
            {
                button_Plot1Scale.Text = "No AutoS";
            }
        }

        private void button_Plot2Scale_Click(object sender, EventArgs e)
        {
            DataLoggerPlot2.ManageAxisLimits = !DataLoggerPlot2.ManageAxisLimits;
            Plot2.Refresh();
            if (DataLoggerPlot2.ManageAxisLimits)
            {
                button_Plot2Scale.Text = "AutoS";
            }
            else
            {
                button_Plot2Scale.Text = "No AutoS";
            }
        }

        private void checkBox_Get_K_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Get_K.Checked)
            {
                checkBox_Get_Sensor.Checked = false;
            }

        }

        private void checkBox_Get_Sensor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Get_Sensor.Checked)
            {
                checkBox_Get_K.Checked = false;
            }
        }

        private void check_channel_A_CheckedChanged(object sender, EventArgs e)
        {
            if (check_channel_A.Checked)
                check_channel_B.Checked = false;
        }
        private void check_channel_B_CheckedChanged(object sender, EventArgs e)
        {
            if (check_channel_B.Checked)
                check_channel_A.Checked = false;
        }


    }
}
