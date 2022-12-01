using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace ISShd
{
	public class EarthMap : Application_Object
	{
        public static List<ISSCoordinate> _ListOfCoordinates = new List<ISSCoordinate>();
        private Bitmap _bitmap = new Bitmap("Earth Map", "Final.png");
        private Craft _craft;
        private double zero_latitude = Convert.ToDouble(Program.HEIGHT / 2);
        private double zero_longitude = Convert.ToDouble(Program.WIDTH / 2);

        private double scaled_latitude = Program.HEIGHT / 180;
        private double scaled_longitude = Program.WIDTH / 360;

		public EarthMap(string name, bool isHuman, string[] id, Craft craft) : base(name, isHuman, id)
		{
            _craft = craft;
            ISSCoordinate temp = new ISSCoordinate(_craft.Latitude(), _craft.Longtitude());
            _ListOfCoordinates.Add(temp);
		}

        public Bitmap Bitmap
        {
            get
            {
                return _bitmap;
            }
        }

        public override string Location()
        {
            return "This is the map of the Earth that presents the current position of the ISS";
        }

        //function that return the correct coordinate of the craft on the visual map

        public double Map_Latitude()
        {
            return zero_latitude - (_craft.Latitude() * scaled_latitude);
        }

        //function that return the correct coordinate of the craft on the visual map

        public double Map_Longitude()
        {
            return zero_longitude + (_craft.Longtitude() * scaled_longitude);
        }

        public void Reset_trajectory()
        {
            if (_ListOfCoordinates.Count != 0)
            {
                _ListOfCoordinates.Clear();
            }
            return; 
        }

        //function to convert data to string 
    }
}

