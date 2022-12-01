using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Threading;
using System.Collections.Generic;
using SplashKitSDK;


namespace ISShd
{
    public class Program
    {
        public const int WIDTH = 1260;
        public const int HEIGHT = 630;

        //-------------pure fabrication for country name-----------------
        public class AdminCodes1
        {
            public string ISO3166_2 { get; set; }
        }

        public class Geoname
        {
            public string adminCode1 { get; set; }
            public string lng { get; set; }
            public string distance { get; set; }
            public int geonameId { get; set; }
            public string toponymName { get; set; }
            public string countryId { get; set; }
            public string fcl { get; set; }
            public int population { get; set; }
            public string countryCode { get; set; }
            public string name { get; set; }
            public string fclName { get; set; }
            public AdminCodes1 adminCodes1 { get; set; }
            public string countryName { get; set; }
            public string fcodeName { get; set; }
            public string adminName1 { get; set; }
            public string lat { get; set; }
            public string fcode { get; set; }
        }

        public class RootLand
        {
            public List<Geoname> geonames { get; set; }
        }
        //-------------pure fabrication for country name-----------------


        //-------------pure fabrication for ocean-----------------

        public class Ocean
        {
            public string distance { get; set; }
            public int geonameId { get; set; }
            public string name { get; set; }
        }

        public class RootOcean
        {
            public Ocean ocean { get; set; }
        }

        //-------------pure fabrication for ocean-----------------

        //-------------pure fabrication for iss postition-----------------
        public class IssPosition
        {
            public string latitude { get; set; }
            public string longitude { get; set; }
        }

        public class RootISS
        {
            public int timestamp { get; set; }
            public IssPosition iss_position { get; set; }
            public string message { get; set; }
        }
        //-------------pure fabrication for iss position------------------

        //Function to get the current ISS position from the internet

        public static void Main(string[] args)
        {
            Window myWindow = new Window("Live Map Of International Space Station", WIDTH, HEIGHT);
            EarthMap _earthmap;
            int updated_times = 0;
            DataTracker _dataTracker = new DataTracker();
            RootISS CurrentLocation()
            {
                string url_current_ISS = "http://api.open-notify.org/iss-now.json";
                var request_current_ISS = WebRequest.Create(url_current_ISS);
                request_current_ISS.Method = "GET";

                using var webResponseForISS = request_current_ISS.GetResponse();
                using var webStreamForISS = webResponseForISS.GetResponseStream();

                using var readerISS = new StreamReader(webStreamForISS);
                var dataISSFromInternet = readerISS.ReadToEnd();

                RootISS decodedDataISS = JsonConvert.DeserializeObject<RootISS>(dataISSFromInternet);
                return decodedDataISS;
            }

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                RootISS DecodedISS = CurrentLocation();
                ISSCoordinate new_point = new ISSCoordinate(Convert.ToDouble(DecodedISS.iss_position.latitude), Convert.ToDouble(DecodedISS.iss_position.longitude));
                _dataTracker.AddData(new_point);

                updated_times += 1;
                Craft _ISScraft = new Craft("ISS", false, new string[] { "iss" }, DecodedISS.iss_position.latitude, DecodedISS.iss_position.longitude);
                _earthmap = new EarthMap("Map", false, new string[] { "map" }, _ISScraft);
                string ISSCoordinate = "(" + DecodedISS.iss_position.latitude+ ", " + DecodedISS.iss_position.longitude + ")";
                string updated_times_string = "Updated times: " + updated_times.ToString();
               

                //drawing the current position of the International Space Station
                SplashKit.FillRectangleOnBitmap( _earthmap.Bitmap, Color.White, 0, HEIGHT - 90, 350, HEIGHT - 90);
                SplashKit.DrawTextOnBitmap(_earthmap.Bitmap, "Current Position", Color.Red, 15, HEIGHT - 70);
                SplashKit.DrawTextOnBitmap(_earthmap.Bitmap, ISSCoordinate, Color.Red, 15, HEIGHT - 60);
                SplashKit.DrawTextOnBitmap(_earthmap.Bitmap, updated_times_string, Color.Red, 15, HEIGHT - 50);
                SplashKit.DrawTextOnBitmap(_earthmap.Bitmap, "Red button to reset trajectory", Color.Black, 15, HEIGHT - 40);
                SplashKit.DrawTextOnBitmap(_earthmap.Bitmap, "Green button to get txt file ISS position", Color.Black, 15, HEIGHT - 30);
                SplashKit.DrawBitmap(_earthmap.Bitmap, 0, 0);

                //draw data button
                DataButton _dataButton = new DataButton(WIDTH - 60, HEIGHT - 60, 50, 50);
                _dataButton.DrawButton(_earthmap.Bitmap);

                //draw clear button
                ClearButton _clearButton = new ClearButton(WIDTH - 120, HEIGHT - 60, 50, 50);
                _clearButton.DrawButton(_earthmap.Bitmap);

                //clicking data button

                if (_dataButton.CheckDimension(SplashKit.MousePosition()))
                {
                    
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        _dataTracker.ExportData();
                        continue;
                    }
                }

                //clicking clear button
                if (_clearButton.CheckDimension(SplashKit.MousePosition()))
                {
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        _earthmap.Reset_trajectory();
                        _dataTracker.ClearData();
                        continue;
                    }
                }

 
                //drawing trajectory of ISS

                foreach (ISSCoordinate point in EarthMap._ListOfCoordinates)
                {
                    SplashKit.FillCircle(Color.Blue, point.LONGITUDE_ON_MAP(), point.LATITUDE_ON_MAP(), 2);
                }

                

                SplashKit.FillCircle(Color.Red, _earthmap.Map_Longitude(), _earthmap.Map_Latitude(), 5);
                SplashKit.DrawCircle(Color.Red, _earthmap.Map_Longitude(), _earthmap.Map_Latitude(), 50);

                SplashKit.RefreshScreen(60);

            } while (!SplashKit.WindowCloseRequested("Live Map Of International Space Station"));
        }
    }
}
