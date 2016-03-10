using UnityEngine;
using System.Collections;

public class Main2 : MonoBehaviour
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
		gameObject.AddComponent<EventManager> ();
		gameObject.AddComponent<Menu2> ();
/*		gameObject.AddComponent<ThemeInitializer> ();
		gameObject.AddComponent<UICreator> ();
		gameObject.AddComponent<PauseManager> ();
		gameObject.AddComponent<SceneCreator> (); */
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
