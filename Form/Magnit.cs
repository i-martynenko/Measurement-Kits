using Measurement_Kits.Device_dll;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Measurement_Kits
{
	public partial class Magnit : Form
	{
		private Form_Menu Form_Menu;
		
		private Danfysik9100 _magnet;
		private Lock_in_Amplifier_SR830 _lock_in_amplifier;
        private Keithley2000 _keithley2000 ;
        private CancellationTokenSource _cts;
		private bool _isRunning = false;
		private int _timeStepMs; // інтервал у мс (можеш змінювати прямо з форми)
		private Queue<(DateTime Time, double Temp)> tempHistory = new Queue<(DateTime, double)>();
		private int measureCounter = 0; // лічильник вимірів для середнього
		public Magnit(Form_Menu menu)
		{
			InitializeComponent();
			Form_Menu = menu;
			GlobalExitHelper.AttachGlobalExit(this);

		}
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
			Plot1.Plot.XLabel("Mag");
			Plot1.Plot.YLabel("Ch1");



			DataLoggerPlot2 = Plot2.Plot.Add.DataStreamerXY(10000);
			Plot2.Plot.XLabel("Mag");
			Plot2.Plot.YLabel("Ch2");




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
				if (ports.Length > 1)
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
		public Magnit()
		{
			InitializeComponent();
		}

		

		private void button_Menu_Click(object sender, EventArgs e)
		{
			GlobalExitHelper.SwitchTo(this, Form_Menu);
		}

		private void Magnit_SizeChanged(object sender, EventArgs e)
		{
			panel1.Height = this.Height - Plot1Sizedifference_hight;
			//panel2.Height = this.Height - Plot2Sizedifference_hight;
			panel1.Width = this.Width - Plot1Sizedifference_widht;
			panel2.Width = this.Width - Plot2Sizedifference_widht;
		}
		private int Plot2Sizedifference_widht, Plot1Sizedifference_widht;
		int Plot1Sizedifference_hight, Plot2Sizedifference_hight;

		private void button_ConnectToLakeShore_Click(object sender, EventArgs e)
		{
			string portName = comboBox2.Text;
			_magnet = new Danfysik9100();
			bool status = _magnet.Connect(portName);
			if (status)
			{
				button_ConnectToLakeShore.BackColor = System.Drawing.Color.Green;
			}
			else
			{
				button_ConnectToLakeShore.BackColor = System.Drawing.Color.Orange;
			}
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			_timeStepMs = (int)numericUpDown1.Value;
		}

		
		private void button_Reset_Click(object sender, EventArgs e)
		{
			_isRunning = false;
			_cts.Cancel();
			_isRunning = false;
			button_Reset.Text = $"Reset {_isRunning}";
			button3.Text = "Start";
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
					button_Reset.Text = $"Reset {_isRunning}";
					if (checkBox_Hysteresis.Checked)
					{
						await Task.Run(() => MeasurementLoopHysteresis(_cts.Token,
						Convert.ToDouble(textBox_Mag_Start.Text),
						Convert.ToDouble(textBox_Mag_Delta.Text),
						Convert.ToDouble(textBox_Mag_End.Text),
						checkBox_Wtite_time_in_file.Checked));
					}
					else
					{
						await Task.Run(() => MeasurementLoop(_cts.Token,
						Convert.ToDouble(textBox_Mag_Start.Text),
						Convert.ToDouble(textBox_Mag_Delta.Text),
						Convert.ToDouble(textBox_Mag_End.Text),
						checkBox_Wtite_time_in_file.Checked));
					}
					
				}
				else
				{
					// Пауза
					_cts.Cancel();
					_isRunning = false;
					button_Reset.Text = $"Reset {_isRunning}";
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

		private void button_ConnectToMultimetr_Click(object sender, EventArgs e)
		{
			string portName = comboBox1.Text;
			bool status = false;

            if (checkBox_Lock_in_Multimeter.Checked)
			{
                _lock_in_amplifier = new Lock_in_Amplifier_SR830();
                status = _lock_in_amplifier.Connect(portName);
            }
			else
			{
				_keithley2000 = new Keithley2000();
				status = _keithley2000.Connect(portName);
            }

			if (status)
			{
				button_ConnectToMultimetr.BackColor = System.Drawing.Color.Green;
			}
			else
			{
				button_ConnectToMultimetr.BackColor = System.Drawing.Color.Orange;
			}
		}
		private async Task MeasurementLoopHysteresis(
			CancellationToken token,
			double magnet_start,
			double magnet_delta,
			double magnet_end,
			bool read_time = false)
		{
			string filePath = label_path.Text;
			if (checkBox_Lock_in_Multimeter.Checked) 
			{
                File.AppendAllText(filePath, "V\tFrequency\tPhase\r\n");

                double freq = _lock_in_amplifier.GetFrequency();
                double phase = _lock_in_amplifier.GetPhase();
                double ampl = _lock_in_amplifier.GetAmplitude();

                File.AppendAllText(filePath, $"{ampl:E8}\t{freq:E8}\t{phase:E8}\r\n");
                if (read_time)
                {
                    File.AppendAllText(filePath,
                        "Time\tMagnet\tChannel1\tChannel2\r\n");
                }
                else
                {
                    File.AppendAllText(filePath,
                        "Magnet\tChannel1\tChannel2\r\n");
                }
			}
			else
			{
                
                if (read_time)
                {
                    File.AppendAllText(filePath,
                        "Time\tMagnet\tMultimeter\r\n");
                }
                else
                {
                    File.AppendAllText(filePath,
                        "Magnet\tMultimeter\r\n");
                }
            }


				var sw = new Stopwatch();
			sw.Start();

			long lastTick = sw.ElapsedMilliseconds;

			double delta = Math.Abs(magnet_delta);

			// 0 -> end -> 0 -> start -> 0
			List<double> points = new List<double>();

			// 0 -> end
			for (double b = 0; b <= magnet_end; b += delta)
				points.Add(b);

			// end -> 0
			for (double b = magnet_end; b >= 0; b -= delta)
				points.Add(b);

			// 0 -> start
			for (double b = 0; b >= magnet_start; b -= delta)
				points.Add(b);

			// start -> 0
			for (double b = magnet_start; b <= 0; b += delta)
				points.Add(b);

			foreach (double magnet_now in points)
			{
				if (token.IsCancellationRequested)
					break;

				_magnet.SetMagneticField(magnet_now);

				while (true)
				{
					long currentTick = sw.ElapsedMilliseconds;
					double elapsedMs = currentTick - lastTick;

					if (elapsedMs >= _timeStepMs)
					{
						lastTick += _timeStepMs;
						break;
					}

					int delay = (int)(_timeStepMs - elapsedMs);

					if (delay > 1)
						await Task.Delay(delay);
					else
						await Task.Yield();
				}

				string time = DateTime.Now.ToString("HH:mm:ss.fff");
                string line;
				double channel1 = 0;
				double channel2 = 0;
				double channel_Multimeter = 0;
                if (checkBox_Lock_in_Multimeter.Checked)
				{
                    channel1 = _lock_in_amplifier.GetDisplayChannel_1();

                    channel2 = _lock_in_amplifier.GetDisplayChannel_2();
                    //AddTemperature(magnet_now);
                    

                    if (read_time)
                    {
                        line =
                            $"{time}\t{magnet_now:E8}\t{channel1:E8}\t{channel2:E8}\r\n";
                    }
                    else
                    {
                        line =
                            $"{magnet_now:E8}\t{channel1:E8}\t{channel2:E8}\r\n";
                    }
                }
				else
				{
					channel_Multimeter = _keithley2000.Get_FETCh();

                    
                    //AddTemperature(magnet_now);


                    if (read_time)
                    {
                        line =
                            $"{time}\t{magnet_now:E8}\t{channel_Multimeter:E8}\r\n";
                    }
                    else
                    {
                        line =
                            $"{magnet_now:E8}\t{channel_Multimeter:E8}\r\n";
                    }
                }


				File.AppendAllText(filePath, line);

				this.Invoke(new Action(() =>
				{
					if (checkBox_Lock_in_Multimeter.Checked) 
					{
                        DataLoggerPlot1.Add(magnet_now, channel1);
                        DataLoggerPlot2.Add(magnet_now, channel2);
                    }
					else
					{
						DataLoggerPlot1.Add(magnet_now, channel_Multimeter);
                        //DataLoggerPlot2.Add(magnet_now, channel_Multimeter);
                    }


                    Plot1.Refresh();
					Plot2.Refresh();
				}));

				await Task.Yield();
			}

			_magnet.SetMagneticField(0);
		}
		private async Task MeasurementLoop(CancellationToken token, double magnet_start, double magnet_delta, double magnet_end, bool read_time = false)
		{
			string filePath = label_path.Text;


            
            if (checkBox_Lock_in_Multimeter.Checked)
            {
                File.AppendAllText(filePath, "V\tFrequency\tPhase\r\n");

                double freq = _lock_in_amplifier.GetFrequency();
                double phase = _lock_in_amplifier.GetPhase();
                double ampl = _lock_in_amplifier.GetAmplitude();

                File.AppendAllText(filePath, $"{ampl:E8}\t{freq:E8}\t{phase:E8}\r\n");
                if (read_time)
                {
                    File.AppendAllText(filePath,
                        "Time\tMagnet\tChannel1\tChannel2\r\n");
                }
                else
                {
                    File.AppendAllText(filePath,
                        "Magnet\tChannel1\tChannel2\r\n");
                }
            }
            else
            {

                if (read_time)
                {
                    File.AppendAllText(filePath,
                        "Time\tMagnet\tMultimeter\r\n");
                }
                else
                {
                    File.AppendAllText(filePath,
                        "Magnet\tMultimeter\r\n");
                }
            }


            var sw = new Stopwatch();
			sw.Start();
			long lastTick = sw.ElapsedTicks;
			
			double magnet_now = magnet_start;
			_magnet.SetMagneticField(magnet_now);
			while (!token.IsCancellationRequested)
			{
				// Обчислюємо час, який пройшов
				long currentTick = sw.ElapsedMilliseconds;
				double elapsedMicroSec = (long)(currentTick - lastTick);
				


				if (elapsedMicroSec >= _timeStepMs) // наприклад, 50 мкс
				{
					lastTick += _timeStepMs;
					var time = DateTime.Now.ToString("HH:mm:ss.fff");
                    string line;
                    double channel1 = 0;
                    double channel2 = 0;
                    double channel_Multimeter = 0;
					
                    if (checkBox_Lock_in_Multimeter.Checked)
                    {
                        channel1 = _lock_in_amplifier.GetDisplayChannel_1();

                        channel2 = _lock_in_amplifier.GetDisplayChannel_2();
                        AddTemperature(magnet_now);


                        if (read_time)
                        {
                            line =
                                $"{time}\t{magnet_now:E8}\t{channel1:E8}\t{channel2:E8}\r\n";
                        }
                        else
                        {
                            line =
                                $"{magnet_now:E8}\t{channel1:E8}\t{channel2:E8}\r\n";
                        }
                    }
                    else
                    {
                        channel_Multimeter = _keithley2000.Get_FETCh();
                        AddTemperature(magnet_now);
                        if (read_time)
                        {
                            line =
                                $"{time}\t{magnet_now:E8}\t{channel_Multimeter:E8}\r\n";
                        }
                        else
                        {
                            line =
                                $"{magnet_now:E8}\t{channel_Multimeter:E8}\r\n";
                        }
                    }
					

					File.AppendAllText(filePath, line);
					measureCounter++;
					if (measureCounter % 3 == 0) // кожні 3 цикли
					{
						double TempSpeed = ComputeTemperatureSlope();
						// Оновлюємо label у GUI-потоці
						this.Invoke(new Action(() =>
						{
							label_TempNow.Text = $"P{magnet_now:f}K";
							label_TempSpeed.Text = $"Temp Speed = {TempSpeed:f3} K/min";
						}));

					}
					// Оновлення графіка на формі
					this.Invoke(new Action(() =>
					{
                        if (checkBox_Lock_in_Multimeter.Checked)
                        {
                            DataLoggerPlot1.Add(magnet_now, channel1);
                            DataLoggerPlot2.Add(magnet_now, channel2);
                        }
                        else
                        {
                            DataLoggerPlot1.Add(magnet_now, channel_Multimeter);
                            //DataLoggerPlot2.Add(magnet_now, channel_Multimeter);
                        }


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
				magnet_now += magnet_delta;
				_magnet.SetMagneticField(magnet_now);
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

		private void button_SetMagne_Click(object sender, EventArgs e)
		{		
			_magnet.SetMagneticField(Convert.ToDouble(textBox_SetMagne.Text));
		}

        private void checkBox_Lock_in_Multimeter_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBox_Lock_in_Multimeter.Checked) 
			{
				label1.Text = "Lock-in Amplifier";
            }
			else
			{
                label1.Text = "Keithley2000";
            }
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

		private void Magnit_Load(object sender, EventArgs e)
		{
			_timeStepMs = (int)numericUpDown1.Value;
			SetupPlots();
			CreatCOM();
			Plot1Sizedifference_widht = this.Size.Width - panel1.Width;
			Plot2Sizedifference_widht = this.Size.Width - panel1.Width;

			Plot1Sizedifference_hight = this.Size.Height - panel1.Height;
			Plot2Sizedifference_hight = this.Size.Height - panel2.Height;
			Magnit_SizeChanged(null, null);

		}
	}
}
