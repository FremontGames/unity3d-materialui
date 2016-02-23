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

    public int toolbarInt = 0;
    public string[] toolbarStrings = new string[] {"Toolbar1", "Toolbar2", "Toolbar3"};
    void OnGUI() {
        GUILayout.BeginHorizontal();
	      if (GUILayout.Button("Play"))
	        play();
	      if (GUILayout.Button("Cancel"))
	        cancel();
	      if (GUILayout.Button("Exit"))
	        exit();
        GUILayout.EndHorizontal();
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
