using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SGUIButton : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		SetSize (this.transform, new Vector2 (150, 50));

		Image image = this.transform.GetComponent<Image> ();
		texture (image, "button_bkg2");

		Button button = this.transform.GetComponent<Button> ();
		transition (button, image, Selectable.Transition.ColorTint);
		colors (button, Color.blue, Color.green, Color.red);
		onClick (button, delegate {
		});
	}


	public static void SetSize (Transform t, Vector2 size)
	{
		RectTransform trans = t.GetComponent<RectTransform> ();

		Vector2 currSize = trans.rect.size;
		Vector2 sizeDiff = size - currSize;
		trans.offsetMin = trans.offsetMin -
		new Vector2 (sizeDiff.x * trans.pivot.x,
			sizeDiff.y * trans.pivot.y);
		trans.offsetMax = trans.offsetMax +
		new Vector2 (sizeDiff.x * (1.0f - trans.pivot.x),
			sizeDiff.y * (1.0f - trans.pivot.y));
	}


	// http://docs.unity3d.com/Manual/script-Button.html
	public static void onClick (Button button, UnityAction _onClick)
	{
		button.interactable = true;
		if (_onClick != null) {
			button.onClick.AddListener (_onClick);
		}
	}

	// http://docs.unity3d.com/ScriptReference/Color32.html
	public static void colors (Button button, Color _normalColor, Color _highlightedColor, Color _pressedColor)
	{
		ColorBlock cb = button.colors;
		cb.normalColor = _normalColor;
		cb.highlightedColor = _highlightedColor;
		cb.pressedColor = _pressedColor;
		cb.colorMultiplier = 1f;
		cb.fadeDuration = 0.1f;
		button.colors = cb;
	}

	// http://docs.unity3d.com/Manual/script-SelectableTransition.html
	public static void transition (Button button, Image image, Selectable.Transition _transition)
	{
		button.transition = _transition;
		if (_transition == Selectable.Transition.ColorTint) {
			button.targetGraphic = image;
		}
	}

	public static void texture (Image image, string _texture)
	{
		Texture2D tex = Resources.Load<Texture2D> (_texture);
		if (tex != null) {
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

}
