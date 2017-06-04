using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelBuilder
{
	Transform _parent;
	float _localScale_w = 1f;
	float _localScale_h = 1f;
	string _tex_path = "";
	Color _color = Color.white;

	public GameObject build ()
	{
		GameObject obj = Builder.build (_parent, 5, "Panel");

		RectTransform trans = obj.AddComponent<RectTransform> ();
		trans.anchorMin = new Vector2 (0, 0);
		trans.anchorMax = new Vector2 (1, 1);
		trans.anchoredPosition3D = new Vector3 (0, 0, 0);
		trans.anchoredPosition = new Vector2 (0, 0);
		trans.offsetMin = new Vector2 (0, 0);
		trans.offsetMax = new Vector2 (0, 0);
		trans.localPosition = new Vector3 (0, 0, 0);
		trans.sizeDelta = new Vector2 (0, 0);
		trans.localScale = new Vector3 (_localScale_w, _localScale_h, 1.0f);

		if (_color != null) {
			CanvasRenderer renderer = obj.AddComponent<CanvasRenderer> ();
			renderer.SetColor (_color);
		}
		if (!string.IsNullOrEmpty (_tex_path)) {
			Image image = obj.AddComponent<Image> ();
			Texture2D tex = Resources.Load<Texture2D> (_tex_path);
			image.sprite = Sprite.Create (tex, new Rect (0, 0, tex.width, tex.height),
				new Vector2 (0.5f, 0.5f));
		}
		return obj;
	}
		
	public static PanelBuilder parent(Transform obj)
	{
		PanelBuilder b = new PanelBuilder ();
		b._parent = obj;
		return b;
	}

	public PanelBuilder localScale_w (float obj)
	{
		_localScale_w = obj;
		return this;
	}


	public PanelBuilder localScale_h (float obj)
	{
		_localScale_h = obj;
		return this;
	}


	public PanelBuilder tex_path (string obj)
	{
		_tex_path = obj;
		return this;
	}


	public PanelBuilder color (Color obj)
	{
		_color = obj;
		return this;
	}

}

