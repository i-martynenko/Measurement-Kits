using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
namespace Measurement_Kits
{
    public partial class Form_Test_RS232 : Form
    {
        private Form_Menu Form_Menu;
        private Keithley2000 _keithley;
        private LakeShore335 _lakeshore;
        private Lock_in_Amplifier_SR830 _sr830;
        private int measureCounter;
        private CancellationTokenSource _cts;
        private int _timeStepMs;
        private int waitMs;
        private bool _isRunning = false;
        public Form_Test_RS232(Form_Menu menu)
        {
            InitializeComponent();
            Form_Menu = menu;
            GlobalExitHelper.AttachGlobalExit(this);
            CreatCOM();
            measureCounter = 0;
            _timeStepMs = (int)numericUpDown1.Value;
            waitMs = (int)numericUpDown_waitms.Value;
            _keithley = new Keithley2000();
            _lakeshore = new LakeShore335();
            _sr830 = new Lock_in_Amplifier_SR830();
        }       

        private void button_SendCommand_Click(object sender, EventArgs e)
        {
            int count = (checkedListBox1.GetItemChecked(0) ? 1 : 0) + (checkedListBox1.GetItemChecked(1) ? 1 : 0) + (checkedListBox1.GetItemChecked(2) ? 1 : 0);

            if (count != 1)
            {
                MessageBox.Show("Треба обрати тільке одне обладнення!");
                return;
            }
            string command = textBox_Respond.Text;
            if (checkedListBox1.GetItemChecked(0))
            {                
                var time = DateTime.Now.ToString("HH:mm:ss.fff");
                string respond = _keithley.SendCommand(command,waitMs);
                richTextBox_Out.Text += $"{time}\t{command}\t{respond}\n";
            }
            if (checkedListBox1.GetItemChecked(1))
            {                
                var time = DateTime.Now.ToString("HH:mm:ss.fff");
                string respond = _lakeshore.SendCommand(command, waitMs);
                richTextBox_Out.Text += $"{time}\t{command}\t{respond}\n";
            }
            if (checkedListBox1.GetItemChecked(2))
            {                
                var time = DateTime.Now.ToString("HH:mm:ss.fff");
                string respond = _sr830.SendCommand(command, waitMs);
                richTextBox_Out.Text += $"{time}\t{command}\t{respond}\n";
            }
        }
        
        private async Task MeasurementLoop(CancellationToken token, string command, DeviceBase Device)
        {
            var sw = new Stopwatch();
            sw.Start();
            long lastTick = sw.ElapsedTicks;

            while (!token.IsCancellationRequested)
            {
                // Обчислюємо час, який пройшов
                long currentTick = sw.ElapsedMilliseconds;
                double elapsedMicroSec = (long)(currentTick - lastTick);

                if (elapsedMicroSec >= _timeStepMs) // наприклад, 50 мкс
                {
                    lastTick += _timeStepMs;
                    var time = DateTime.Now.ToString("HH:mm:ss.fff");
                    string respond = Device.SendCommand(command, waitMs);
                    this.Invoke(new Action(() =>
                    {
                        richTextBox_Out.Text += $"{measureCounter}\t{command}\t{time}\t{respond}\n";
                    }));
                    measureCounter++;
                }
                else
                {
                    int delay = (int)(_timeStepMs - elapsedMicroSec);
                    if (delay>1)
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
        
        private async void button_LoopSendCommand_Click(object sender, EventArgs e)
        {
            int count = (checkedListBox1.GetItemChecked(0) ? 1 : 0) + (checkedListBox1.GetItemChecked(1) ? 1 : 0) + (checkedListBox1.GetItemChecked(2) ? 1 : 0);

            if (count != 1)
            {
                MessageBox.Show("Треба обрати тільке одне обладнення!");
                return;                
            }
            string command = textBox_Respond.Text;
            try
            {
                if (!_isRunning)
                {
                    // Запуск
                    _cts = new CancellationTokenSource();
                    _isRunning = true;
                    button_LoopSendCommand.BackColor = Color.Green;

                    if (checkedListBox1.GetItemChecked(0))
                    {
                        await Task.Run(() => MeasurementLoop(_cts.Token, command,_keithley));
                    }
                    if (checkedListBox1.GetItemChecked(1))
                    {
                        await Task.Run(() => MeasurementLoop(_cts.Token, command,_lakeshore));
                    }
                    if (checkedListBox1.GetItemChecked(2))
                    {
                        await Task.Run(() => MeasurementLoop(_cts.Token, command, _sr830));
                    }                    
                }
                else
                {
                    // Пауза
                    _cts.Cancel();
                    _isRunning = false;
                    button_LoopSendCommand.BackColor = Color.Gray;
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
        private void button_Menu_Click(object sender, EventArgs e)
        {
            GlobalExitHelper.SwitchTo(this, Form_Menu);
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
        private void CreatCOM()
        {
            comboBox1.Items.Clear();
            string[] ports = SerialPort.GetPortNames(); // Отримати список портів

            comboBox1.Items.AddRange(ports);
            comboBox2.Items.AddRange(ports);
            comboBox3.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                comboBox1.SelectedIndex = 1; // вибрати перший порт
                comboBox2.SelectedIndex = 2;
                comboBox3.SelectedIndex = 0;
            }
            else
                comboBox1.Text = "Немає портів";
        }
        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _timeStepMs = (int)numericUpDown1.Value;
        }

        private void button_Clr_Click(object sender, EventArgs e)
        {
            richTextBox_Out.Text = "";
        }

        private void button_ConnectToSR830_Click(object sender, EventArgs e)
        {
            string portName = comboBox3.Text;
           
            _sr830 = new Lock_in_Amplifier_SR830();
            bool status = _sr830.Connect(portName);
            if (status)
            {
                button_ConnectToSR830.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                button_ConnectToSR830.BackColor = System.Drawing.Color.Orange;
            }
        }

        private void numericUpDown_waitms_ValueChanged(object sender, EventArgs e)
        {
            waitMs = (int)numericUpDown_waitms.Value;
        }

        private void Form_Test_RS232_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var time = DateTime.Now.ToString("HH:mm:ss.fff");
            double respond = _sr830.GetAmplitude();
            richTextBox_Out.Text += $"{time}\tAMP\t{respond}\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var time = DateTime.Now.ToString("HH:mm:ss.fff");
            double respond = _sr830.GetFrequency();
            richTextBox_Out.Text += $"{time}\tGetFrequency\t{respond}\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var time = DateTime.Now.ToString("HH:mm:ss.fff");
            double respond = _sr830.GetPhase();
            richTextBox_Out.Text += $"{time}\tGetFrequency\t{respond}\n";
        }
    }
}
