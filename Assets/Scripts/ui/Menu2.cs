using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Menu2 : MonoBehaviour
{
	UIFactory2 f = new UIFactory2();

	// Use this for initialization
	void Start ()
	{

		GameObject canvas = f.CreateCanvas(this.transform);

//		f.CreateEventSystem(canvas.transform);
		EventManager.StartListening ("test", reaction);

		GameObject panel = f.CreatePanel(canvas.transform);

		f.CreateText(panel.transform, 0, 100, 160, 50, "Message", 32);
		f.CreateText(panel.transform, 0, 0, 160, 50, "Are you sure, you want to exit?", 24);

		f.CreateButton(panel.transform, -100, -100, 160, 50, "Yes", delegate {action();});
//		f.CreateButton(panel.transform, 100, -100, 160, 50, "No", delegate {OnCancel();});


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
		EventManager.TriggerEvent ("test");
	}
	private void reaction()
	{
		Debug.Log("Menu2:reaction...");
	}

}
