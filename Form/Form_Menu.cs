using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Measurement_Kits
{
    public partial class Form_Menu : Form
    {        
        public Form_Menu()
        {
            InitializeComponent();
            GlobalExitHelper.AttachGlobalExit(this, isMainForm: true);
        }

        private void button_Transport_Click(object sender, EventArgs e)
        {
            var form_Transport = new Form_Transport(this);
            GlobalExitHelper.SwitchTo(this, form_Transport, hideInsteadOfClose: true);

        }

        private void Form_Menu_Load(object sender, EventArgs e)
        {
            

        }

        private void button_Test_Plot_Click(object sender, EventArgs e)
        {

        }

        private void button_Test_RS232_Click(object sender, EventArgs e)
        {
            var form_Test_RS232 = new Form_Test_RS232(this);
            GlobalExitHelper.SwitchTo(this, form_Test_RS232, hideInsteadOfClose: true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form_Magnetic_Multi = new Form_Magnetic_Multi(this);
            GlobalExitHelper.SwitchTo(this, form_Magnetic_Multi, hideInsteadOfClose: true);
        }
    }
    }
