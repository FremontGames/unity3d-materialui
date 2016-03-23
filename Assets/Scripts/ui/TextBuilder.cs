using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBuilder
{
	Transform _parent;
	float _x = 0;
	float _y = 0;
	float _w = 160;
	float _h = 50;
	string _text = "Text";
	int _fontSize = 24;

	public GameObject build ()
	{
		GameObject obj = Builder.build (_parent, 5, "Text");

		RectTransform trans = obj.AddComponent<RectTransform> ();
		trans.sizeDelta.Set (_w, _h);
		// http://docs.unity3d.com/ScriptReference/Vector3.html
		trans.anchoredPosition3D = new Vector3 (0, 0, 0);
		// http://docs.unity3d.com/ScriptReference/Vector2.html
		trans.anchoredPosition = new Vector2 (_x, _y);
		trans.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		trans.localPosition.Set (0, 0, 0);

		CanvasRenderer renderer = obj.AddComponent<CanvasRenderer> ();

		Text text = obj.AddComponent<Text> ();
		text.supportRichText = true;
		text.text = _text;
		text.fontSize = _fontSize;
		text.font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font;
		text.alignment = TextAnchor.MiddleCenter;
		text.horizontalOverflow = HorizontalWrapMode.Overflow;
		text.color = new Color (0, 0, 1);

		return obj;
	}


	public static TextBuilder parent(Transform obj)
	{
		TextBuilder b = new TextBuilder ();
		b._parent = obj;
		return b;
	}

	public TextBuilder x (float obj)
	{
		_x = obj;
		return this;
	}

	public TextBuilder y (float obj)
	{
		_y = obj;
		return this;
	}

	public TextBuilder w (float obj)
	{
		_w = obj;
		return this;
	}

	public TextBuilder h (float obj)
	{
		_h = obj;
		return this;
	}

	public TextBuilder text (string obj)
	{
		_text = obj;
		return this;
	}

	public TextBuilder fontSize (int obj)
	{
		_fontSize = obj;
		return this;
	}

}

