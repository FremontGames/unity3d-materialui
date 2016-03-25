using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ButtonBuilder
{
	Transform _parent;
	float _x = 0;
	float _y = 0;
	float _w = 300;
	float _h = 70;

	string _texture = "button_bkg";
	Selectable.Transition _transition = Selectable.Transition.ColorTint;
	Color _normalColor = new Color (255, 255, 255, 1);
	Color _highlightedColor = new Color (0, 0, 0, 1);
	Color _pressedColor = Color.grey;

	string _text = "Button";
	Color _text_color = Color.black;

	Color _shadow = new Color (50, 50, 50, 1);


	UnityAction _onClick = delegate {
		
	};

	public GameObject build ()
	{
		GameObject obj = Builder.build (_parent, 5, "Button");

		RectTransform trans = obj.AddComponent<RectTransform> ();
		SetSize (trans, new Vector2 (_w, _h));
		trans.anchoredPosition3D = new Vector3 (0, 0, 0);
		trans.anchoredPosition = new Vector2 (_x, _y);
		trans.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		trans.localPosition.Set (0, 0, 0);

		CanvasRenderer renderer = obj.AddComponent<CanvasRenderer> ();


		Image image = obj.AddComponent<Image> ();

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

		// http://docs.unity3d.com/Manual/script-Button.html
		Button button = obj.AddComponent<Button> ();
		button.interactable = true;
		if (_onClick != null) {
			button.onClick.AddListener (_onClick);
		}
		if (_transition != null) {
			// http://docs.unity3d.com/Manual/script-SelectableTransition.html
			button.transition = _transition;
			if (_transition == Selectable.Transition.ColorTint) {
				button.targetGraphic = image;
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


		// TODO notif

		if (_shadow != null) {
			// http://docs.unity3d.com/Manual/script-Shadow.html
			// http://docs.unity3d.com/460/Documentation/ScriptReference/UI.Shadow.html
			Shadow shadow = obj.AddComponent<Shadow> ();
			shadow.effectColor = _shadow;
			shadow.effectDistance = new Vector2 (5, -5);
		}
		if (!string.IsNullOrEmpty (_text)) {
			TextBuilder
			.parent (obj.transform)
				.text (_text)
				.color (_text_color)
			.build ();
		}
		return obj;
	}

	public static void SetSize (RectTransform trans, Vector2 size)
	{
		Vector2 currSize = trans.rect.size;
		Vector2 sizeDiff = size - currSize;
		trans.offsetMin = trans.offsetMin -
		new Vector2 (sizeDiff.x * trans.pivot.x,
			sizeDiff.y * trans.pivot.y);
		trans.offsetMax = trans.offsetMax +
		new Vector2 (sizeDiff.x * (1.0f - trans.pivot.x),
			sizeDiff.y * (1.0f - trans.pivot.y));
	}


	public static ButtonBuilder parent (Transform obj)
	{
		ButtonBuilder b = new ButtonBuilder ();
		b._parent = obj;
		return b;
	}

	public ButtonBuilder x (float obj)
	{
		_x = obj;
		return this;
	}

	public ButtonBuilder y (float obj)
	{
		_y = obj;
		return this;
	}

	public ButtonBuilder w (float obj)
	{
		_w = obj;
		return this;
	}

	public ButtonBuilder h (float obj)
	{
		_h = obj;
		return this;
	}

	public ButtonBuilder text (string obj)
	{
		_text = obj;
		return this;
	}

	public ButtonBuilder texture (string obj)
	{
		_texture = obj;
		return this;
	}

	public ButtonBuilder normalColor (Color obj)
	{
		_normalColor = obj;
		return this;
	}

	public ButtonBuilder onClick (UnityAction obj)
	{
		_onClick = obj;
		return this;
	}

	public ButtonBuilder text_color (Color obj)
	{
		_text_color = obj;
		return this;
	}


}
