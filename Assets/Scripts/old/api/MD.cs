using UnityEngine;

namespace DFREMONT.UI
{
	public class MD : MonoBehaviour
	{
		public static Element button (params Element[] childs)
		{
			return new Element ().childs(childs);
		}

		public static Element content (params Element[] childs)
		{
			return new Element ().childs(childs);
		}

		public static Element section (params Element[] childs)
		{
			return new Element ().childs(childs);
		}

		public static Element label (string arg)
		{
			return new Element ().text (arg);
		}

	}
}