using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Menu : MonoBehaviour
{
	// VIEW

	void Start ()
	{
		GameObject c = UIFactory.CreateCanvas (this.transform);
		GameObject p = UIFactory.CreatePanel (c.transform);
		UIFactory.CreateText (p.transform, 0, 100, 160, 50, "Tests", 32);
		UIFactory.CreateText (p.transform, 0, 0, 160, 50, "Choose a demo", 24);
		UIFactory.CreateButton (p.transform, 0, -100, 300, 70, "Quit", delegate {
			quit ();
		});
		UIFactory.CreateButton (p.transform, 0, -200, 300, 70, "Editor", delegate {
			editor ();
		});
		UIFactory.CreateButton (p.transform, 0, -300, 300, 70, "Map", delegate {

		});

	}

	// PRESENTER

	void quit ()
	{
		DestroyImmediate (this);
		GameObject m = new GameObject ("Quit");
		m.AddComponent<Quit> ();
	}

	void editor ()
	{
		Destroy (this);
		GameObject m = new GameObject ("Editor");
		m.AddComponent<Editor> ();
	}

}
