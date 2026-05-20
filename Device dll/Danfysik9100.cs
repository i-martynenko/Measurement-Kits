using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace Measurement_Kits.Device_dll
{
	class Danfysik9100: DeviceBase
	{
		public Danfysik9100() : base(9600, 8, Parity.None,
				StopBits.One, "\r", Handshake.None, 1000,
				"Danfysik System 9100")
		{

		}
		public override object ParseResponse(string response)
		{
			if (double.TryParse(response, out double value))
				return value;
			return response;
		}
		public void SetMagneticField(double value,int waitMs = 100) 
		{
			int int_value = (int)(value * 1000.0);
			if (int_value > 999999)
				int_value = 999999;
			if (int_value < -999999)
				int_value = -999999;
			if ((int_value == 0))
			{
				string resp = SendCommand($"DA 0 +0\r", waitMs);
				return;
			}	
			if (int_value < -1)
			{
				int_value = -int_value;
				string resp = SendCommand($"DA 0 -{int_value}\r", waitMs);
				return;
			}
			if (int_value > 0)
			{
				string resp = SendCommand($"DA 0 +{int_value}\r", waitMs);
				return;
			}

		}
	}
}
