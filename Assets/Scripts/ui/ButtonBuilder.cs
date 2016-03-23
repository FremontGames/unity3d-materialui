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
	string _text = "Button";
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

		// Image
		Image image = obj.AddComponent<Image> ();
		init (image, "button_bkg");

		// Button Script
		Button button = obj.AddComponent<Button> ();
		button.interactable = true;
		button.onClick.AddListener (_onClick);

		// Button states
		// http://answers.unity3d.com/questions/792008/how-to-change-normal-color-highlighted-color-etc-i.html
		button.transition = Selectable.Transition.ColorTint;
		ColorBlock cb = button.colors;
		button.targetGraphic = image;
		cb.normalColor = Color.grey;
		cb.highlightedColor = Color.red;
		cb.pressedColor = Color.green;
		cb.colorMultiplier = 1f;
		cb.fadeDuration = 0.1f;
		button.colors = cb;

		TextBuilder
			.parent (obj.transform)
			.text (_text)
			.build ();

		return obj;
	}

	public static  void init (Image image, string resource)
	{
		Texture2D tex = Resources.Load<Texture2D> (resource);

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

	public ButtonBuilder onClick (UnityAction obj)
	{
		_onClick = obj;
		return this;
	}

}
