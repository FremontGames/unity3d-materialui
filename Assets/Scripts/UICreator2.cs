using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

// https://unity3d.com/learn/tutorials/topics/user-interface-ui
public class UICreator2 : MonoBehaviour {


	void OnGUI() {

		// STYLE
		// http://docs.unity3d.com/Manual/gui-Customization.html
		// http://docs.unity3d.com/Manual/class-GUIStyle.html
		GUIStyle button_style = GUI.skin.GetStyle ("button");
		button_style.fontSize = CommonProperties.fontSize; 

		/*
		GUI.backgroundColor = Color.yellow;
		GUI.Button(new Rect(10, 10, 70, 30), "A button");
		*/

		// http://docs.unity3d.com/ScriptReference/RectOffset-ctor.html
		button_style.border = new RectOffset(1,1,10,30);
		// NORMAL
		// http://docs.unity3d.com/ScriptReference/Material-color.html
		button_style.normal.textColor = Color.grey;
		// http://docs.unity3d.com/ScriptReference/Resources.Load.html
		button_style.normal.background = (Texture2D) Resources.Load("test.png", typeof(Texture2D));
		// HOVER
		button_style.onHover.textColor = Color.black;
		// ACTIVE
		button_style.active.textColor = Color.blue;
		// button_style.active.background = (Texture2D) Resources.Load("test.png", typeof(Texture2D));

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
