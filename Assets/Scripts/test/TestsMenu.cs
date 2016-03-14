using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TestsMenu : MonoBehaviour
{
	UIFactory f = new UIFactory();

	// Use this for initialization
	void Start ()
	{

		GameObject canvas = f.CreateCanvas(this.transform);

//		f.CreateEventSystem(canvas.transform);
		EventManager.StartListening ("exec:EditorTest", reaction);
		EventManager.StartListening ("exec", reaction);

		GameObject panel = f.CreatePanel(canvas.transform);

		// make builder pattern or json
		f.CreateText(panel.transform, 0, 100, 160, 50, "Tests", 32);
		f.CreateText(panel.transform, 0, 0, 160, 50, "Choose a demo", 24);

		f.CreateButton(panel.transform, 0, -100, 300, 70, "Main", delegate {action();});
		f.CreateButton(panel.transform, 0, -200, 300, 70, "Editor", delegate {action2();});
		f.CreateButton(panel.transform, 0, -300, 300, 70, "Map", delegate {action2();});

		/*

		UnityAction someListener = new UnityAction (reaction);
		EventManager.StartListening ("test", someListener);


		GameObject canvasObject = new GameObject("Canvas2");
		f.initCanvas (canvasObject);

//		GameObject canvasObject2 = f.initCanvas2(this);

		f.initButton2 (canvasObject, "tet3", delegate { action(); });

		// http://docs.unity3d.com/Manual/JSONSerialization.html
		// myObject = JsonUtility.FromJson<MyClass>(json);
		*/
	}

	// Update is called once per frame
	void Update ()
	{
	
	}

	private void action()
	{
		Debug.Log("Menu2:action...");
		EventManager.TriggerEvent ("exec:MainMenu");
	}
	private void action2()
	{
		Debug.Log("Menu2:action2...");
		EventManager.TriggerEvent ("exec:EditorTest");
	}


	private void reaction()
	{
		Debug.Log("Menu2:reaction...");
		Destroy (this);
		GameObject gameObject = GameObject.Find ("Main Camera");
		gameObject.AddComponent<EditorTest> ();
	}

}
