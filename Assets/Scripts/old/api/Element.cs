using UnityEngine;
using System.Collections.Generic;

namespace DFREMONT.UI
{
	public class Element : MonoBehaviour
	{
		public Dictionary<string, string> _attributs = new Dictionary<string, string> ();
		public Element[] _childs = new Element[0];

		public Element() 
		{
			int id = Random.Range(1, 999999);
			_attributs ["id"] = ""+id;
		}

		public Element className (string arg)
		{
			_attributs ["className"] = arg;
			return this;
		}

		public Element id (string arg)
		{
			_attributs ["id"] = arg;
			return this;
		}

		public Element disabled (bool arg)
		{
			_attributs ["disabled"] = arg.ToString ();
			return this;
		}

		public Element text (string arg)
		{
			_attributs ["text"] = arg;
			return this;
		}

		public Element childs (params Element[] childs)
		{
			_childs = childs;
			return this;
		}

		//

		public Element layout (string arg)
		{
			_attributs ["layout"] = arg;
			return this;
		}
	}
}

