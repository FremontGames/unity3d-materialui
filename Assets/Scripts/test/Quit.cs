using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Quit : MonoBehaviour
{
	UIFactory f = new UIFactory();

	// VIEW ***********************************************

	// Use this for initialization
	void Start ()
	{
		GameObject canvas = f.CreateCanvas(/*this.transform*/);

//		f.CreateEventSystem(canvas.transform);
		EventManager.StartListening ("test", reaction);

		GameObject panel = f.CreatePanel(canvas.transform);

		// make builder pattern or json
		f.CreateText(panel.transform, 0, 100, 160, 50, "Message", 32);
		f.CreateText(panel.transform, 0, 0, 160, 50, "Are you sure, you want to exit?", 24);

		f.CreateButton(panel.transform, 0, -100, 160, 50, "Yes", delegate {action();});
		f.CreateButton(panel.transform, 0, -200, 160, 50, "Yes", delegate {action2();});
//		f.CreateButton(panel.transform, 100, -100, 160, 50, "No", delegate {OnCancel();});

	}

	// Update is called once per frame
	void Update ()
	{
	
	}

	// PRESENTER ***********************************************


	private void action()
	{
		Debug.Log("Menu2:action...");
		EventManager.TriggerEvent ("test1");
	}

	private void action2()
	{
		Debug.Log("Menu2:action2...");
		EventManager.TriggerEvent ("test2");
	}

	private void reaction()
	{
		Debug.Log("Menu2:reaction...");
	}

}
