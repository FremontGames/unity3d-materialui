using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SGUIButton : MonoBehaviour
{

	// Use this for initialization (when added script to gameobject)
	public void Start ()
	{
		Debug.Log("Start");
		var trans = this.transform;
		init (trans);
	}

	// Use this for initialization (when calling directly))
	public static void init(Transform trans) {
		SetSize (trans, new Vector2 (SGUIStyle.width, SGUIStyle.height));

		Image image = trans.GetComponent<Image> ();
		texture (image, SGUIStyle.texture);

		Button button = trans.GetComponent<Button> ();
		transition (button, image, Selectable.Transition.ColorTint);
		colors (button, SGUIStyle.normalColor, SGUIStyle.highlightedColor, SGUIStyle.pressedColor);
		onClick (button, delegate {
		});

		var text = trans.GetComponentInChildren<Text> ();
		localization (text, "fr");

	}

	public static void localization (Text text, string fr)
	{
		text.text = "FR";
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
