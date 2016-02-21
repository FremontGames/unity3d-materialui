using UnityEngine;
using System;

public class SceneCreator : MonoBehaviour
{
	GameObject sphere;

	void Start()
	{
		sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);	

		// Destroy(sphere);

	}
}
