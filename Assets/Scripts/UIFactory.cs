using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

// http://chikkooos.blogspot.fr/2015/03/new-ui-implementation-using-c-scripts.html
public class UIFactory : MonoBehaviour
{

	private const int LayerUI = 5;

	public static GameObject CreateCanvas (Transform parent)
	{
		// create the canvas
		GameObject canvasObject = new GameObject ("Canvas");
		canvasObject.layer = LayerUI;
		RectTransform canvasTrans = canvasObject.AddComponent<RectTransform> ();
		// Canvas
		Canvas canvas = canvasObject.AddComponent<Canvas> ();
		// http://docs.unity3d.com/Manual/UICanvas.html
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		canvas.pixelPerfect = true;
		// Canvas Scaler
		// http://docs.unity3d.com/ScriptReference/UI.CanvasScaler.html
		CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler> ();
/*		canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPhysicalSize;
		canvasScaler.physicalUnit = CanvasScaler.Unit.Points;
*/		canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		canvasScaler.referenceResolution = new Vector2(800, 600);

		GraphicRaycaster canvasRayc = canvasObject.AddComponent<GraphicRaycaster> ();

		canvasObject.transform.SetParent (parent);
		return canvasObject;
	}

	public static GameObject CreateEventSystem (Transform parent)
	{
		GameObject esObject = new GameObject ("EventSystem");

		EventSystem esClass = esObject.AddComponent<EventSystem> ();
		esClass.sendNavigationEvents = true;
		esClass.pixelDragThreshold = 5;

		StandaloneInputModule stdInput = esObject.AddComponent<StandaloneInputModule> ();
		stdInput.horizontalAxis = "Horizontal";
		stdInput.verticalAxis = "Vertical";

		TouchInputModule touchInput = esObject.AddComponent<TouchInputModule> ();

		esObject.transform.SetParent (parent);

		return esObject;
	}

	public static GameObject CreatePanel (Transform parent)
	{
		GameObject panelObject = new GameObject ("Panel");
		panelObject.transform.SetParent (parent);

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
		trans.localScale = new Vector3 (0.8f, 0.8f, 1.0f);

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

	public static GameObject CreateText (Transform parent, float x, float y,
	                             float w, float h, string message, int fontSize)
	{
		GameObject textObject = new GameObject ("Text");
		textObject.transform.SetParent (parent);

		textObject.layer = LayerUI;

		RectTransform trans = textObject.AddComponent<RectTransform> ();
		trans.sizeDelta.Set (w, h);
		trans.anchoredPosition3D = new Vector3 (0, 0, 0);
		trans.anchoredPosition = new Vector2 (x, y);
		trans.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		trans.localPosition.Set (0, 0, 0);

		CanvasRenderer renderer = textObject.AddComponent<CanvasRenderer> ();

		Text text = textObject.AddComponent<Text> ();
		text.supportRichText = true;
		text.text = message;
		text.fontSize = fontSize;
		text.font = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font;
		text.alignment = TextAnchor.MiddleCenter;
		text.horizontalOverflow = HorizontalWrapMode.Overflow;
		text.color = new Color (0, 0, 1);

		return textObject;
	}

	public static GameObject CreateButton (Transform parent, float x, float y,
	                               float w, float h, string message,
	                               UnityAction eventListner)
	{
		GameObject buttonObject = new GameObject ("Button");
		buttonObject.transform.SetParent (parent);

		buttonObject.layer = LayerUI;

		RectTransform trans = buttonObject.AddComponent<RectTransform> ();
		SetSize (trans, new Vector2 (w, h));
		trans.anchoredPosition3D = new Vector3 (0, 0, 0);
		trans.anchoredPosition = new Vector2 (x, y);
		trans.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		trans.localPosition.Set (0, 0, 0);

		CanvasRenderer renderer = buttonObject.AddComponent<CanvasRenderer> ();

		// Image
		Image image = buttonObject.AddComponent<Image> ();
		init (image, "button_bkg");

		// Button Script
		Button button = buttonObject.AddComponent<Button> ();
		button.interactable = true;
		button.onClick.AddListener (eventListner);

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


		GameObject textObject = CreateText (buttonObject.transform, 0, 0, 0, 0,
			                        message, 24);

		return buttonObject;
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

}		