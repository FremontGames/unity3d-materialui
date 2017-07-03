using UnityEngine;
using UnityEngine.UI;
using MDUI.Style;

namespace MDUI.Component
{
	public class MDText : MDComponent
	{

		public override void init() 
		{
			Text txt = this.GetComponentInChildren<Text> ();
			if (txt == null) {
				txt = gameObject.AddComponent<Text>();
			}
			txt.text = "New Text";
		}

		public override void apply ()
		{
			Text txt = this.GetComponentInChildren<Text> ();
			if (txt != null) {
				txt.font = MDTypographyManager.get ().font;
				txt.fontSize = MDTypographyManager.get ().body1.fontSize;
				txt.fontStyle = MDTypographyManager.get ().body1.fontStyle;
                
				txt.color = MDTheme.get ().color;
				// SCALE
				txt.resizeTextForBestFit = true;
				txt.resizeTextMinSize = 12;
				txt.resizeTextMaxSize = 40;
				txt.alignment = TextAnchor.MiddleCenter;
			}
		}
	}
}
