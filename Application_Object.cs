using System;
namespace ISShd
{
	public abstract class Application_Object : Object_Management
	{
		private string _name;
		private bool _human;

		public Application_Object(string name, bool isHuman, string[] id) : base(id)
		{
			_name = name;
			_human = isHuman;
		}

		//properties
		public string GetFullName
		{
			get
			{
				return _name;
			}
		}

		public bool IsAstronaut
		{
			get
			{
				return _human;
			}
		}

		public abstract string Location();
	}
}

