using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBuilder
{
	Transform _parent;

	public TextBuilder (Transform parent)
	{
		_parent = parent;
	}

	public GameObject build ()
	{
		GameObject textObject = new GameObject ("Text");
		textObject.transform.SetParent (_parent);
		textObject.layer = LayerUI;

		RectTransform trans = textObject.AddComponent<RectTransform> ();
		trans.sizeDelta.Set (_w, _h);
		// http://docs.unity3d.com/ScriptReference/Vector3.html
		trans.anchoredPosition3D = new Vector3 (0, 0, 0);
		// http://docs.unity3d.com/ScriptReference/Vector2.html
		trans.anchoredPosition = new Vector2 (_x, _y);
		trans.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		trans.localPosition.Set (0, 0, 0);

		CanvasRenderer renderer = textObject.AddComponent<CanvasRenderer> ();

		Text text = textObject.AddComponent<Text> ();
		text.supportRichText = true;
		text.text = _text;
		text.fontSize = _fontSize;
		text.font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font;
		text.alignment = TextAnchor.MiddleCenter;
		text.horizontalOverflow = HorizontalWrapMode.Overflow;
		text.color = new Color (0, 0, 1);

		return textObject;
	}

	private const int LayerUI = 5;

	float _x = 0;
	float _y = 0;
	float _w = 160;
	float _h = 50;
	string _text = "Hello";
	int _fontSize = 24;

	public TextBuilder x (float newValue)
	{
		_x = newValue;
		return this;
	}

	public TextBuilder y (float newValue)
	{
		_y = newValue;
		return this;
	}

	public TextBuilder w (float newValue)
	{
		_w = newValue;
		return this;
	}

	public TextBuilder h (float newValue)
	{
		_h = newValue;
		return this;
	}

	public TextBuilder text (string newValue)
	{
		_text = newValue;
		return this;
	}

	public TextBuilder fontSize (int newValue)
	{
		_fontSize = newValue;
		return this;
	}

}

