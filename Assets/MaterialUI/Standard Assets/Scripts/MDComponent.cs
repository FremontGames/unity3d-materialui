using System;
using UnityEngine;

namespace MDUI.Component
{
	public abstract class MDComponent : MonoBehaviour
	{
		public bool editorUpdateChilds = true;

		public abstract void Create();

		public static GameObject Create<T> (string name, Action<T> vars) where T:MDComponent{
			GameObject obj = new GameObject(name);
			T cmp = obj.AddComponent<T>();
			vars (cmp);
			cmp.Create ();
			return obj;
		}
	}
}

