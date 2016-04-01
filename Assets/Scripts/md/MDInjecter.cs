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

	void inject (Transform parent)
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
			child.gameObject.AddComponent<SGUIButton> ();
		}
	}
}

