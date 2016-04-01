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
		int size = parent.childCount;
		for (int i = 0; i < size; i++) {
			Transform child = parent.GetChild(i);
			string name = child.name.ToLower();
			if(name.Contains("md") ) {
				if (name.EndsWith("mdbutton")) {
					// TODO apply theme
//					theme(child.gameObject);
					Debug.Log(name);
					child.gameObject.AddComponent<SGUIButton>();
				}
			}
		}
	}
	
	void texture(Image image, string _texture) {
		if (!string.IsNullOrEmpty (_texture)) {
			Texture2D tex = Resources.Load<Texture2D> (_texture);

			// IF scliced
			// http://docs.unity3d.com/ScriptReference/Sprite.Create.html
			float pixelsPerUnit = 100.0f;
			uint extrude = 0;
			SpriteMeshType meshType = SpriteMeshType.Tight;
			// http://docs.unity3d.com/450/Documentation/ScriptReference/Sprite-border.html
			// Vector4 border = Vector4.zero;
			// http://docs.unity3d.com/ScriptReference/Vector4.html
			Vector4 border = new Vector4 (10, 10, 10, 10);
			image.type = Image.Type.Sliced;

			// ELSE
			// image.type = Image.Type.Simple;

			image.sprite = Sprite.Create (tex, new Rect (0, 0, tex.width, tex.height),
				new Vector2 (0.5f, 0.5f), pixelsPerUnit, extrude, meshType, 
				border);
		}

	}

	void theme(GameObject go) {
		Image[] images = go.GetComponentsInChildren<Image> ();
		Debug.Log (images);
		for (int i = 0; i < images.Length; i++) {
			Image image = images[i];
			texture (image, "button_bkg2");
		}
		Button[] buttons = go.GetComponentsInChildren<Button> ();
		for (int i = 0; i < buttons.Length; i++) {
			Button button = buttons[i];

			button.transition = _transition;
			if (_transition == Selectable.Transition.ColorTint) {
				//				button.targetGraphic = image;
				// http://docs.unity3d.com/ScriptReference/Color32.html
				ColorBlock cb = button.colors;
				cb.normalColor = _normalColor;
				cb.highlightedColor = _highlightedColor;
				cb.pressedColor = _pressedColor;
				cb.colorMultiplier = 1f;
				cb.fadeDuration = 0.1f;
				button.colors = cb;
			}
		}
	}

	Selectable.Transition _transition = Selectable.Transition.ColorTint;
	Color _normalColor = new Color (255, 255, 255, 1);
	Color _highlightedColor = new Color (0, 0, 0, 1);
	Color _pressedColor = Color.grey;

}

