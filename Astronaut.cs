using System;
namespace ISShd
{
	public class Astronaut : Application_Object
	{
		private string _craft;
		public Astronaut(string name, bool isHuman, string[] id, string craft) : base(name, isHuman, id)
		{
			_craft = craft;
		}

		//override function

		public override string Location()
		{
			return "The astronaut is in " + _craft;
		}


	}
}

