using System;
using System.IO;
using System.Collections.Generic;
namespace ISShd
{
	public class DataTracker
	{
		private static List<string> ISS_Data;
		public DataTracker()
		{
			ISS_Data = new List<string>();
		}

		public void AddData(ISSCoordinate _ISScoordinate)
        {
			string data = _ISScoordinate.iss_position_data();
			ISS_Data.Add(data);
        }

		public void ClearData()
        {
			ISS_Data.Clear();
        }

       
        public void ExportData()
        {
			if (ISS_Data.Count == 0)
            {
				return;
            }
            else
            {
				File.WriteAllLinesAsync("DataISS.txt", ISS_Data);
			}
        }
	}
}

