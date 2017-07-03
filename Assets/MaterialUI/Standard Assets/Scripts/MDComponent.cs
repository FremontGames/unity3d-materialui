using System;
using UnityEngine;

namespace MDUI.Component
{
	public abstract class MDComponent : MonoBehaviour
	{
		public abstract void init ();
		public abstract void apply ();

		// RUNTIME: Use this for initialization
		void Awake()
		{
			Debug.Log ("Awake");
			// init ();
		}

		// RUNTIME: Use after initialization
		void Start ()
		{
			Debug.Log ("Start");
			apply ();
		}

		// EDITOR: Use this for editor reset component button
		void Reset ()
		{
			Debug.Log ("Reset");
			init ();
			apply ();
		}

		// EDITOR: Use this for editor update inspector
		void OnValidate()
		{
			Debug.Log ("OnValidate");
			apply ();
		}
			
	}
}

