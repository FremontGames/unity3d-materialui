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


		// VENDOR OBJECTS
		GameObject em = new GameObject ("EventManager");
		UIFactory.CreateEventSystem (em.transform);
		em.AddComponent<EventManager> ();

		GameObject sm = new GameObject ("ScreenManager");
		sm.AddComponent<ScreenManager> ();

		// go.AddComponent<ThemeInitializer> ();
		// gameObject.AddComponent<PauseManager> ();

		// CORE OBJECTS
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
