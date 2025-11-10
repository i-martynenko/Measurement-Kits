using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Measurement_Kits
{
   
    class LakeShore335 : DeviceBase
    {
        //"LSCI,MODEL335,LSA2Q6U/LSA2QB6,2.0"
        
        public LakeShore335() : base(57600, 7, Parity.Odd,
            StopBits.One, "\n", Handshake.None, 2000,
            "LSCI,MODEL335")
        {
           
            
        }
        public override object ParseResponse(string response)
        {
            if (double.TryParse(response, out double value))
                return value;
            return response;
        }
        public double GetTemperature_K(string channel = "A",int wait = 50) 
        {
            
            string resp = SendCommand($"KRDG? {channel}",wait);
            return resp != null ? (double)ParseResponse2(resp) : double.NaN;    
        }
        public double GetSensor(string channel = "A", int wait = 50)
        {

            string resp = SendCommand($"SRDG? {channel}", wait);
            return resp != null ? (double)ParseResponse2(resp) : double.NaN;
        }
    }
}
