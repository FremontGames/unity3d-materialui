using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TestsMenu : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		// VIEW
		UIFactory f = new UIFactory ();
		// f.CreateEventSystem(canvas.transform);
		GameObject c = f.CreateCanvas (this.transform);
		GameObject p = f.CreatePanel (c.transform);
		f.CreateText (p.transform, 0, 100, 160, 50, "Tests", 32);
		f.CreateText (p.transform, 0, 0, 160, 50, "Choose a demo", 24);
		f.CreateButton (p.transform, 0, -100, 300, 70, "Main", delegate {
			EventManager.TriggerEvent ("open:MainMenu");
		});
		f.CreateButton (p.transform, 0, -200, 300, 70, "Editor", delegate {
			EventManager.TriggerEvent ("open:EditorTest");
		});
		f.CreateButton (p.transform, 0, -300, 300, 70, "Map", delegate {
			EventManager.TriggerEvent ("exec:MapMenu");
		});

		// PRESENTER
		EventManager.StartListening ("open:MainMenu", delegate {
			Destroy (this);
			GameObject.Find ("Main Camera").AddComponent<MainMenu> ();
		});
		EventManager.StartListening ("open:EditorTest", delegate {
			Destroy (this);
			GameObject.Find ("Main Camera").AddComponent<EditorTest> ();
		});
	}

}
