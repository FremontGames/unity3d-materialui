using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Main : MonoBehaviour
{

	GameObject gameObject;

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Main:Started!");
		gameObject = GameObject.Find ("Main Camera");
		if (null == gameObject) {
			Debug.Log ("EditorStartup:gameObject 'Main Camera' must not be null!");
		}
//		CommonProperties.init ();

		CreateEventSystem(this.transform);


		gameObject.AddComponent<EventManager> ();
		gameObject.AddComponent<Menu2> ();
/*		gameObject.AddComponent<ThemeInitializer> ();
		gameObject.AddComponent<UICreator> ();
		gameObject.AddComponent<PauseManager> ();
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
		
		TouchInputModule touchInput = esObject.AddComponent<TouchInputModule>();
		
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
