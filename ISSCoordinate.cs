using System;
using System.Globalization;
namespace ISShd
{
	public class ISSCoordinate
	{
		private double _latitude;
		private double _longitude;
		private double zero_latitude = Convert.ToDouble(Program.HEIGHT / 2);
		private double zero_longitude = Convert.ToDouble(Program.WIDTH / 2);
		private double scaled_latitude = Program.HEIGHT / 180;
		private double scaled_longitude = Program.WIDTH / 360;

		public ISSCoordinate(double latitude, double longitude)
		{
			_latitude = latitude;
			_longitude = longitude;
		}

		public double LATITUDE_ON_MAP()
        {        
			return zero_latitude - (_latitude * scaled_latitude);
        }

		public double LONGITUDE_ON_MAP()
        {
			return zero_longitude + (_longitude * scaled_longitude);
        }

		public string iss_position_data()
        {			
			string result = "(" + _latitude.ToString() + ", " + _longitude.ToString() + ") , " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " (GMT+7)";
			return result;
        }


	}
}

