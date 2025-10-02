using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.IO.Ports;

namespace Measurement_Kits
{
    public class Keithley2000 : DeviceBase
    {

        // "KEITHLEY INSTRUMENTS INC.,MODEL 2000,1319343,A20  /A02"
        string[] res;
        public Keithley2000() : base(9600,8, Parity.None,
            StopBits.One,"\r\n",Handshake.None,2000,
            "KEITHLEY INSTRUMENTS INC.") 
        {
            
            var list = new List<string>();
            List<string> ress = new List<string>();
            string resourceName = "Measurement_Kits.1.txt";
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    MessageBox.Show($"Не вдалося знайти ресурс {resourceName}");
                    return;
                }

                using (StreamReader sr = new StreamReader(stream))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
            }            
            for (int i = 0; i < list.Count; i++)
            {
                string temp = list[i];
                temp = temp.Trim();
                temp = temp.Split('\t')[1]; // 3 - 2
                Console.WriteLine();
                ress.Add(temp);
            }
            res = ress.ToArray();
        }
        public override object ParseResponse(string response)
        {
            if (double.TryParse(response, out double value))
                return value;
            return response;
        }
        public void SetDC_I() { }
        public void SetAC_I() { }
        public void SetDC_V() { }
        public void SetAC_V() { }
        public void SetDC_R() { }
        public void SetAC_R() { }
        
        public void Set_INIT_COUNT_ON(int waitMs = 100) 
        {
            string resp = SendCommand(":INIT:CONT ON", waitMs);
            
        }

        public double Get_FETCh(int waitMs = 55) 
        {
            string resp = SendCommand(":FETCh?", waitMs);
            return resp != null ? (double) ParseResponse(resp) : double.NaN;
            
        }   
        public double GetRead(int waitMs = 70) 
        {
            string resp = SendCommand(":READ?",waitMs);
            return resp != null ? (double)ParseResponse(resp) : double.NaN;
            
        }   
        public double MeasureVoltage()
        {
            string resp = SendCommand("MEAS:VOLT:DC?");
            return resp != null ? (double)ParseResponse(resp) : double.NaN;
        }

        public double MeasureCurrent()
        {
            string resp = SendCommand("MEAS:CURR:DC?");
            return resp != null ? (double)ParseResponse(resp) : double.NaN;
        }
        public double MeasureResistance()
        {
            string resp = SendCommand("EMUL-Keithley");            
            return resp != null ? (double)ParseResponse2(resp) : double.NaN;
        }
        public double MeasureResistance(int i)
        {
            string resp = SendCommand("EMUL-Keithley");
            resp = res[i];
            return resp != null ? (double)ParseResponse2(resp) : double.NaN;
        }


    }
}
