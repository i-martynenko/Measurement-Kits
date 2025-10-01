using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace Measurement_Kits
{
    public class Keithley2000 : InstrumentBase
    {
        string[] res;
        public Keithley2000() 
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
