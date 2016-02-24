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
		GUIStyle style = GUI.skin.GetStyle ("button");
		style.fontSize = fontSize;
		// UI
        GUILayout.BeginHorizontal();
		if (GUILayout.Button("Play"))
	        play();
		if (GUILayout.Button("Cancel"))
	        cancel();
		if (GUILayout.Button("Exit"))
	        exit();
        GUILayout.EndHorizontal();
		Debug.Log(fontSize);
	}

	private void Update () {

	}
	
	private void play()	{
		Debug.Log("UI:play");
	}

	private void Start() {
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
