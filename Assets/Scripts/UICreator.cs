using UnityEngine;
using System;

public class UICreator : MonoBehaviour
{
	 
	// Layer 5 is used for UI
	private const int LayerUI = 5;

	void Start ()
	{
		Debug.Log("UICreator:Start");
		CreateUI ();
	}

	void Update ()
	{
	}

	private void CreateUI ()
	{
		GameObject canvasObject = new GameObject("Canvas");
		canvasObject.layer = LayerUI;
		canvasObject.transform.SetParent(this.transform);
	}
}