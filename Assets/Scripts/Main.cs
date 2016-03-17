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

		// EVENT BUS
		CreateEventSystem(this.transform);

		// INIT SCRIPTS
		GameObject go = new GameObject("Cool GameObject made from Code");
		go.AddComponent<ThemeInitializer> ();
		go.AddComponent<EventManager> ();
		go.AddComponent<Menu> ();
/*		gameObject.AddComponent<PauseManager> ();
		gameObject.AddComponent<SceneCreator> (); */
	}

	private GameObject CreateEventSystem(Transform parent) {
		GameObject esObject = new GameObject("EventSystem");
		
		EventSystem esClass = esObject.AddComponent<EventSystem>();
		esClass.sendNavigationEvents = true;
		esClass.pixelDragThreshold = 5;
		
		StandaloneInputModule stdInput = esObject.AddComponent<StandaloneInputModule>();
		stdInput.horizontalAxis = "Horizontal";
		stdInput.verticalAxis = "Vertical";
		
//		TouchInputModule touchInput = esObject.AddComponent<TouchInputModule>();
		
		esObject.transform.SetParent(parent);
		
		return esObject;
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
