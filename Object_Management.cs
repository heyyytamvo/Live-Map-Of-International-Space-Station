using System;
using System.Collections.Generic;
namespace ISShd
{
	public class Object_Management
	{
            private List<string> _ListOfObject;

            //contructor
            public Object_Management(string[] ids)
            {
                _ListOfObject = new List<string>();
                foreach (string element in ids)
                {
                    _ListOfObject.Add(element);
                }
            }

            //function
            public bool InApplication(string id)
            {
                return _ListOfObject.Contains(id);
            }
        
    }
}

