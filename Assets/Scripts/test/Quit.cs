using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Quit : MonoBehaviour
{

	// VIEW ***********************************************

	void Start ()
	{
		GameObject canvas = UIFactory.CreateCanvas (this.transform);
		GameObject panel = UIFactory.CreatePanel (canvas.transform);
		UIFactory.CreateText (panel.transform, 0, 100, 160, 50, "Message", 32);
		UIFactory.CreateText (panel.transform, 0, 0, 160, 50, "Are you sure, you want to exit?", 24);
		UIFactory.CreateButton (panel.transform, 0, -100, 160, 50, "Yes", delegate {
			yes ();
		});
		UIFactory.CreateButton (panel.transform, 0, -200, 160, 50, "No", delegate {
			no ();
		});
	}
		
	// PRESENTER ***********************************************

	private void yes ()
	{
		Application.Quit ();
	}

	private void no ()
	{
		Destroy (GameObject.Find ("Quit"));
		new GameObject ("Menu").AddComponent<Menu> ();
	}
}
