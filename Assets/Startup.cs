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
		gameObject.AddComponent<Main2>();
		Debug.Log("EditorStartup:Linking done!");
	}
}
