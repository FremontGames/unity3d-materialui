using UnityEngine;
using UnityEngine.UI;
using MDUI.Style;

namespace MDUI.Component
{
	public class MDText : MDComponent
	{
		void OnValidate() 
		{
			SetText ();
		}

		void Reset ()
		{

		}

		public override void Create ()
		{	
			OnValidate ();
		}

		private void SetText() {
			Text txt = gameObject.GetComponent<Text> ();
			if (null == txt) {
				txt = gameObject.AddComponent<Text> ();
			}
//			txt.font = MDTypographyManager.get ().font;
//			txt.fontSize = MDTypographyManager.get ().body1.fontSize;
//			txt.fontStyle = MDTypographyManager.get ().body1.fontStyle;

			// Color c;
			// txt.color = MDTheme.get ().backgroundPaletteContrastDefaultColor;

			// SCALE
			txt.resizeTextForBestFit = true;
			txt.resizeTextMinSize = 12;
			txt.resizeTextMaxSize = 40;
			txt.alignment = TextAnchor.MiddleCenter;
		}

	}
}
