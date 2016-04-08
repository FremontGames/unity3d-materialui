using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MDInjecter : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Transform parent = this.transform;
		inject (parent);
	}

	public static void inject (Transform parent)
	{
		for (int i = 0; i < parent.childCount; i++) {
			Transform child = parent.GetChild (i);
			inject (child);
			string childName = child.name.ToLower ();
			if (childName.Contains ("md")) {
				assign (childName, child);
			}
		}
	}

	static void assign (string name, Transform child)
	{
		Debug.Log (name);
		if (name.EndsWith ("mdbutton")) {
			if (null == child.gameObject.GetComponent<SGUIButton> ()) {
				child.gameObject.AddComponent<SGUIButton> ();
			}
		}
	}


	//

	public static void preview (Transform parent)
	{
		for (int i = 0; i < parent.childCount; i++) {
			Transform child = parent.GetChild (i);
			inject (child);
			string childName = child.name.ToLower ();
			if (childName.Contains ("md")) {
				assign2 (childName, child);
			}
		}
	}

	static void assign2 (string name, Transform child)
	{
		Debug.Log (name);
		if (name.EndsWith ("mdbutton")) {
//			if (null == child.gameObject.GetComponent<SGUIButton> ()) {
				SGUIButton.init (child.gameObject.transform);
//			}
		}
	}

}
