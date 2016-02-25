using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

/*
 * see http://chikkooos.blogspot.fr/2015/03/new-ui-implementation-using-c-scripts.html
 */
public class UICreator : MonoBehaviour {

	int fontSize;

	void OnGUI() {
		// STYLE
		// http://docs.unity3d.com/Manual/gui-Customization.html
		GUIStyle style = GUI.skin.GetStyle ("button");
		style.fontSize = fontSize;
		// UI
		// http://docs.unity3d.com/ScriptReference/GUILayout.BeginArea.html
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Play"))
	        play();
		if (GUILayout.Button("Cancel"))
	        cancel();
			if (GUILayout.Button("Exit"))
	        exit();
        GUILayout.EndHorizontal();

		// BAR
		// http://docs.unity3d.com/ScriptReference/GUILayout.FlexibleSpace.html
		GUILayout.BeginArea(new Rect(10, Screen.height/2, Screen.width-(10*2), 60));
		GUILayout.BeginHorizontal();
			GUILayout.Button("LEFT");
			GUILayout.FlexibleSpace();
			GUILayout.Button("RIGHT");
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		// TODO anchors
		// http://docs.unity3d.com/Manual/HOWTO-UIMultiResolution.html
	}

	private void Update () {

	}
	
	private void play()	{
		Debug.Log("UI:play");
	}

	private void Start() {
		// http://docs.unity3d.com/ScriptReference/Application-platform.html
		// OS
		if (Application.platform == RuntimePlatform.WindowsPlayer) {
			Debug.Log("setting for Desktop");
			fontSize = Screen.width / 40;
		}
		// MOBILE
		else {
			Debug.Log("setting for Mobile");
			fontSize = Screen.width / 20;
		}
	}

	private void exit()	{
		Debug.Log("UI:exit");
		Application.Quit();
	}

	private void cancel()	{
		Debug.Log("UI:cancel");
		GameObject.Destroy(this);
	}
}
