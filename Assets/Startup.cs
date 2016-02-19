using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class Startup {
	static Startup()
	{
		Debug.Log("Up and running");
		Debug.Log("Linking...");
		GameObject gameObject = GameObject.Find("Main Camera");
		Debug.Log("gameObject:"+gameObject);
		gameObject.AddComponent<Main2>();
		Debug.Log("Linking done!");
	}
}
