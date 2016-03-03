using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

// https://unity3d.com/learn/tutorials/topics/user-interface-ui
public class Menu : MonoBehaviour {


	void OnGUI() {

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


		// MIDDLE BAR
		// http://docs.unity3d.com/ScriptReference/GUILayout.FlexibleSpace.html
		GUILayout.BeginArea(new Rect(10, Screen.height/2, Screen.width-(10*2), 60));
		GUILayout.BeginHorizontal();
		GUILayout.Button("LEFT");
		GUILayout.FlexibleSpace();
		GUILayout.Button("RIGHT");
		GUILayout.EndHorizontal();
		GUILayout.EndArea();


		// BOTTOM BAR
		GUILayout.BeginArea(new Rect(10, 120, Screen.width-(10*2), 60));
		GUILayout.BeginHorizontal();
		GUILayout.Button("ACTION");
		GUILayout.EndArea();

	}

	private void Update () {

	}

	private void play()	{
		Debug.Log("UI:play");
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
