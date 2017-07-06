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
			// init ();
		}

		// RUNTIME: Use after initialization
		void Start ()
		{
			apply ();
		}

		// EDITOR: Use this for editor reset component button
		void Reset ()
		{
			init ();
			apply ();
		}

		// EDITOR: Use this for editor update inspector
		void OnValidate()
		{
			apply ();
		}
			
	}
}

