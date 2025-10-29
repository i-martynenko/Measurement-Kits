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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
namespace Measurement_Kits
{
    public partial class Form_Magnetic_Multimetr : Form
    {
        public Form_Magnetic_Multimetr()
        {
            InitializeComponent();
        }
        private void CreatCOM()
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
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
