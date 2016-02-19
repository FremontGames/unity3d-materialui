using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class Startup {
	static Startup()
	{
		Debug.Log("----------------------------");
		Debug.Log("EditorStartup:Up and running");
		Debug.Log("EditorStartup:Linking...");
		GameObject gameObject = GameObject.Find("Main Camera");
		if (null == gameObject) {
			Debug.Log("EditorStartup:gameObject 'Main Camera' must not be null!");
		}
		Component script = gameObject.GetComponent<Main2>();
		if (null == script) {
			Debug.Log("EditorStartup:setting Main script!");
			gameObject.AddComponent<Main2> ();
		}
		// TODO if have component remove component
		Debug.Log("EditorStartup:Linking done!");
	}
}
