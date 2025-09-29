using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Measurement_Kits
{
    class LakeShore335 : InstrumentBase
    {
        string[] res;
        public LakeShore335() 
        {
            string path = @"A:\MyPrograms\Measurement Kits\1.txt";
            var list = new List<string>();
            List<string> ress = new List<string>();
            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                string temp = list[i];
                temp = temp.Trim();
                temp = temp.Split('\t')[0]; // 3 - 2
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
        public double MeasureTemperature() 
        {
            string resp = SendCommand("EMUL-LakeShore");
            return resp != null ? (double)ParseResponse2(resp) : double.NaN;
        }
        public double MeasureTemperature(int i)
        {
            string resp = SendCommand("EMUL-Keithley");
            resp = res[i];
            return resp != null ? (double)ParseResponse2(resp) : double.NaN;
        }
    }
}
