using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Menu2 : MonoBehaviour
{
	UIFactory f = new UIFactory();

	// Use this for initialization
	void Start ()
	{
		GameObject canvasObject = new GameObject("Canvas");
		canvasObject.transform.SetParent(this.transform);
		f.initCanvas (canvasObject);

//		GameObject canvasObject2 = f.initCanvas2(this);

		f.initButton2 (canvasObject, "tet3", delegate { action(); });
/*		GameObject[] childs = { 
			buttonObject2
		};
*/
		// TODO
		// canvas "c1"
		//	button "b1"
		//		text "test1"
		//	button "b2"
		//		text "test2"
	}

	// Update is called once per frame
	void Update ()
	{
	
	}
	private void action()
	{
		Debug.Log("Menu2:action...");
	}

}

