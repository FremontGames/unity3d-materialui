using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DFREMONT.UI;

public class Main : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		// UIFactory.CreateElement (this.transform, 0, 0, 100, 100);

		//GameObject content = UIFactory.CreateCanvas (this.transform);
		//GameObject panel = UIFactory.CreatePanel (content.transform);


		ElementRenderer renderer = new ElementRenderer ();

//		renderer.clean (demo);
		Element demo = new ButtonDemos ().start ();
		renderer.start (demo, this.transform, 0, 0, 800, 600);

		// UIFactory.CreateElement (this.transform, 0, 0, 100, 100);



		//		CommonProperties.init ();

/*
		// VENDOR OBJECTS
		GameObject em = new GameObject ("EventManager");
		UIFactory.CreateEventSystem (em.transform);
		em.AddComponent<EventManager> ();

		GameObject sm = new GameObject ("ScreenManager");
		sm.AddComponent<ScreenManager> ();
*/
		// go.AddComponent<ThemeInitializer> ();
		// gameObject.AddComponent<PauseManager> ();

		// CORE OBJECTS
//		GameObject m = new GameObject ("Menu");
//		m.AddComponent<Menu> ();

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
