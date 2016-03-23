using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelBuilder
{
	Transform _parent;

	public PanelBuilder(Transform parent){
		_parent = parent;
	}

	public GameObject build () {
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
		trans.localScale = new Vector3 (_w, _h, 1.0f);

		CanvasRenderer renderer = panelObject.AddComponent<CanvasRenderer> ();

		// TRANSITION
		// http://docs.unity3d.com/ScriptReference/Color.Lerp.html
		float fadeSpeed = 0.5f;
		Color lerpedColor = Color.Lerp(Color.white, Color.black, fadeSpeed);
		renderer.SetColor (lerpedColor);

		Image image = panelObject.AddComponent<Image> ();
		Texture2D tex = Resources.Load<Texture2D> ("panel_bkg");
		image.sprite = Sprite.Create (tex, new Rect (0, 0, tex.width, tex.height),
			new Vector2 (0.5f, 0.5f));

		return panelObject;
	}

	private const int LayerUI = 5;

	float _w = 1f;
	float _h = 1f;

	public PanelBuilder w (float newValue) {
		_w = newValue; return this;
	}
	public PanelBuilder h (float newValue) {
		_h = newValue; return this;
	}

}

