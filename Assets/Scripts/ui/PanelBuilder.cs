using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelBuilder
{
	Transform _parent;

	public PanelBuilder (Transform parent)
	{
		_parent = parent;
	}

	public GameObject build ()
	{
		GameObject panelObject = new GameObject ("Panel");
		panelObject.transform.SetParent (_parent);
		panelObject.layer = LayerUI;

		RectTransform trans = panelObject.AddComponent<RectTransform> ();
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
			CanvasRenderer renderer = panelObject.AddComponent<CanvasRenderer> ();
			renderer.SetColor (_color);
		}
		if (!string.IsNullOrEmpty (_tex_path)) {
			Image image = panelObject.AddComponent<Image> ();
			Texture2D tex = Resources.Load<Texture2D> (_tex_path);
			image.sprite = Sprite.Create (tex, new Rect (0, 0, tex.width, tex.height),
				new Vector2 (0.5f, 0.5f));
		}
		return panelObject;
	}

	private const int LayerUI = 5;

	float _localScale_w = 1f;
	float _localScale_h = 1f;
	string _tex_path = "";
	Color _color = Color.white;

	public PanelBuilder localScale_w (float newValue)
	{
		_localScale_w = newValue;
		return this;
	}

	public PanelBuilder localScale_h (float newValue)
	{
		_localScale_h = newValue;
		return this;
	}

	public PanelBuilder tex_path (string newValue)
	{
		_tex_path = newValue;
		return this;
	}

	public PanelBuilder color (Color newValue)
	{
		_color = newValue;
		return this;
	}

}

