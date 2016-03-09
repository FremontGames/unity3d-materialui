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
		GameObject canvasObject = new GameObject("Canvas2");
		f.initCanvas (canvasObject);

//		GameObject canvasObject2 = f.initCanvas2(this);

		f.initButton2 (canvasObject, "tet3", delegate { action(); });
/*		GameObject[] childs = { 
			buttonObject2
		};
*/
		// TODO HTML to Canvas
		// canvas(
		//	button(
		//		text("test1"))
		//,
		//	button(
		//		text("test2"), )
		//)
		// http://docs.unity3d.com/Manual/JSONSerialization.html
		// myObject = JsonUtility.FromJson<MyClass>(json);
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

