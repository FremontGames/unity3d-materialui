using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ThemeInitializer : MonoBehaviour {

	void OnGUI() {

		// STYLE
		// http://docs.unity3d.com/Manual/gui-Customization.html
		// http://docs.unity3d.com/Manual/class-GUIStyle.html
		GUIStyle button_style = GUI.skin.GetStyle ("button");
		button_style.fontSize = CommonProperties.fontSize; 


		Texture2D tex = Resources.Load<Texture2D>("button_bkg");

		// http://docs.unity3d.com/ScriptReference/RectOffset-ctor.html
		button_style.border = new RectOffset(1,1,10,30);
		// NORMAL
		// http://docs.unity3d.com/ScriptReference/Material-color.html
		button_style.normal.textColor = Color.grey;
		// http://docs.unity3d.com/ScriptReference/Resources.Load.html
		button_style.normal.background = tex;
		// HOVER
		button_style.onHover.textColor = Color.black;
		// ACTIVE
		button_style.active.textColor = Color.blue;
		// button_style.active.background = (Texture2D) Resources.Load("test.png", typeof(Texture2D));
	}

}
