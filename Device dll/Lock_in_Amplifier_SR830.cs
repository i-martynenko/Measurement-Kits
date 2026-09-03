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
  
    public class Lock_in_Amplifier_SR830 : DeviceBase
    {
        // "Stanford_Research_Systems,SR830,s/n42767,ver1.07"
        
        public Lock_in_Amplifier_SR830() : base(9600, 8, Parity.None,
            StopBits.One, "\n", Handshake.None, 2000,
            "Stanford_Research_Systems")
        {
           
        }
        public override object ParseResponse(string response)
        {
            if (double.TryParse(response, out double value))
                return value;
            return response;
        }
        
        public double GetAmplitude(int waitMs = 45)
        {
            string resp = SendCommand("SLVL?", waitMs);
            return resp != null ? (double)ParseResponse(resp) : double.NaN;
        }
        public double GetFrequency(int waitMs = 45)
        {
            string resp = SendCommand("FREQ?", waitMs);
            return resp != null ? (double)ParseResponse(resp) : double.NaN;
        }
        public double GetPhase(int waitMs = 45)
        {
            string resp = SendCommand("PHAS?", waitMs);
            return resp != null ? (double)ParseResponse(resp) : double.NaN;
        }
        public double GetDisplayChannel_1(int waitMs = 45)
        {
            string resp = SendCommand("OUTR? 1", waitMs);
            return resp != null ? (double)ParseResponse(resp) : double.NaN;
        }
        public double GetDisplayChannel_2(int waitMs = 45)
        {
            string resp = SendCommand("OUTR? 2", waitMs);
            return resp != null ? (double)ParseResponse(resp) : double.NaN;
        }
        public void SetFrequency(double frequency, int waitMs = 45)
		{
			SendCommand($"FREQ {frequency}", waitMs);
		}



	}
}
