using System;
namespace ISShd
{
	public class Craft : Application_Object
	{
		private string _longTiTude;
		private string _latTiTude;

		public Craft(string name, bool isHuman, string[] id, string latTiTude, string longTiTude) : base(name, isHuman, id)
		{
			_longTiTude = longTiTude;
			_latTiTude = latTiTude;
		}

		public override string Location()
		{
			return "The spaceship is currently at " + _latTiTude + ", " + _longTiTude;

		}

		//function to get the longtitude of the craft as double data type
		public double Longtitude()
		{
			return Convert.ToDouble(_longTiTude);
		}

		//function to get the latitude of the craft as double data type
		public double Latitude()
		{
			return Convert.ToDouble(_latTiTude);
		}
	}
}

