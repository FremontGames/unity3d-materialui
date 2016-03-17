using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Main : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
//		CommonProperties.init ();


		// INIT SCRIPTS
		GameObject go = new GameObject ("Core");
		UIFactory.CreateEventSystem (go.transform);
		go.AddComponent<ThemeInitializer> ();
		go.AddComponent<EventManager> ();
		/*
		 * gameObject.AddComponent<PauseManager> ();
		gameObject.AddComponent<SceneCreator> (); */

		// FIRST SCREEN
		GameObject m = new GameObject ("Menu");
		m.AddComponent<Menu> ();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnApplicationQuit ()
	{
		Debug.Log ("Main:Application ending after " + Time.time + " seconds");
	}
}
