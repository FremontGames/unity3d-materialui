using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CommonProperties
{
	public static int fontSize;

	public static void init() {
		// http://docs.unity3d.com/ScriptReference/Application-platform.html
		// OS
		if (Application.platform == RuntimePlatform.WindowsPlayer) {
			Debug.Log("setting for Desktop");
			fontSize = Screen.width / 40;
		}
		// MOBILE
		else {
			Debug.Log("setting for Mobile");
			fontSize = Screen.width / 15;
		}
	}

}

	