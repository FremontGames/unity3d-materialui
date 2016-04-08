// TODO exclude from build
using UnityEngine;

using UnityEditor;

// http://docs.unity3d.com/Manual/RunningEditorCodeOnLaunch.html
[InitializeOnLoad]
public class Startup {
	static Startup()
	{
		Debug.Log("----------------------------");
		Debug.Log("EditorStartup:Up and running");
		EditorApplication.update += Update;
/*
		GameObject gameObject = GameObject.Find("Main Camera");
		if (null == gameObject) {
			Debug.Log("EditorStartup:gameObject 'Main Camera' must not be null!");
		}
		Component script = gameObject.GetComponent<Main2>();
		if (null == script) {
			Debug.Log("EditorStartup:setting Main script!");
			gameObject.AddComponent<Main2> ();
		}
*/
	}

	static void Update ()
	{
		Debug.Log("Updating");
		GameObject obj = GameObject.Find ("menu");
		if (null != obj) {
			Debug.Log("menu");
			// INJECT
			MDInjecter.preview (obj.transform);
			// START
			SGUIButton[] s = obj.GetComponents<SGUIButton>();
			for (int i = 0; i < s.Length; i++) {
				Debug.Log("s"+s);
				s [i].Start();
			}
		}
	}
}

