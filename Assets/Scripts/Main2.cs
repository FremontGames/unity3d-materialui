using UnityEngine;
using System.Collections;

public class Main2 : MonoBehaviour {

	GameObject sphere;

	// Use this for initialization
	void Start () {
		Debug.Log("Main:Started!");
		sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnApplicationQuit() {
		Debug.Log("Main:Application ending after " + Time.time + " seconds");
		Destroy(sphere);
	}
}
