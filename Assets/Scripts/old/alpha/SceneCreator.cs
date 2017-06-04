using UnityEngine;
using System;

public class SceneCreator : MonoBehaviour
{
	GameObject sphere;

	void Start()
	{
		sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);	

		GameObject cam = GameObject.Find("Main Camera");
		cam.transform.LookAt(sphere.transform);


		// Destroy(sphere);
	}
}
