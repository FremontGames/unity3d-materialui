using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
		
public class UIFactory {

/*
	public  void init(Image image, string resource) {
		Texture2D tex = Resources.Load<Texture2D>(resource);

		// IF scliced
		// http://docs.unity3d.com/ScriptReference/Sprite.Create.html
		float pixelsPerUnit = 100.0f;
		uint extrude = 0;
		SpriteMeshType meshType = SpriteMeshType.Tight;
		// http://docs.unity3d.com/450/Documentation/ScriptReference/Sprite-border.html
		// Vector4 border = Vector4.zero;
		// http://docs.unity3d.com/ScriptReference/Vector4.html
		Vector4 border = new Vector4(10, 10,10, 10);
		image.type = Image.Type.Sliced;

		// ELSE
		// image.type = Image.Type.Simple;

		image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height),
			new Vector2(0.5f, 0.5f), pixelsPerUnit, extrude, meshType, 
			border);		
	}
*/
	public void initText(GameObject textObject, string message) {
		int x2 = 0;
		int y2 = 0;
		int w2 = 0;
		int h2 = 0;

		RectTransform trans = textObject.AddComponent<RectTransform>();
		trans.sizeDelta.Set(w2, h2);
		trans.anchoredPosition3D = new Vector3(0, 0, 0);
		trans.anchoredPosition = new Vector2(x2, y2);
		trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		trans.localPosition.Set(0, 0, 0);

		CanvasRenderer renderer = textObject.AddComponent<CanvasRenderer>();

		Text text = textObject.AddComponent<Text>();
		text.supportRichText = true;
		text.text = message;
		text.fontSize = 14;
		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.alignment = TextAnchor.MiddleCenter;
		text.horizontalOverflow = HorizontalWrapMode.Overflow;
		text.color = Color.white;

	}

	public GameObject initButton2(GameObject parent, string label, UnityAction eventListner) {
		GameObject buttonObject = new GameObject("Button2");
		buttonObject.transform.SetParent(parent.transform);
		 initButton (buttonObject, label, eventListner);
		return buttonObject;
	}		

	public void initButton(GameObject buttonObject, string label, UnityAction eventListner) {
		int x = 0;
		int y = 50;
		int w = 160;
		int h = 30;

		// RectTransform
		RectTransform buttonTrans = buttonObject.AddComponent<RectTransform>();

		Vector2 size = new Vector2 (w, h);

		Vector2 currSize = buttonTrans.rect.size;
		Vector2 sizeDiff = size - currSize;
		buttonTrans.offsetMin = buttonTrans.offsetMin -
			new Vector2(sizeDiff.x * buttonTrans.pivot.x,
				sizeDiff.y * buttonTrans.pivot.y);
		buttonTrans.offsetMax = buttonTrans.offsetMax + 
			new Vector2(sizeDiff.x * (1.0f - buttonTrans.pivot.x),
				sizeDiff.y * (1.0f - buttonTrans.pivot.y));


		buttonTrans.anchoredPosition3D = new Vector3(0, 0, 0);
		buttonTrans.anchoredPosition = new Vector2(x, y);
		buttonTrans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		buttonTrans.localPosition.Set(0, 0, 0);
/*
		// Image
		Image image = buttonObject.AddComponent<Image>();
		init(image, "button_bkg");
*/
		// Button Script
/*		Button button = buttonObject.AddComponent<Button>();
		button.interactable = true;
		button.onClick.AddListener(eventListner);
*/
/*		// Button animation
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
*/
		{
			GameObject textObject = new GameObject("Text");
			textObject.transform.SetParent(buttonObject.transform);
			initText (textObject, label);
		}

	}

	public void initCanvas(GameObject canvasObject) {
		// RectTransform
		RectTransform canvasTrans = canvasObject.AddComponent<RectTransform>();
		// Canvas
		Canvas canvas = canvasObject.AddComponent<Canvas>();
		// http://docs.unity3d.com/Manual/UICanvas.html
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		// Canvas Scaler
		// http://docs.unity3d.com/ScriptReference/UI.CanvasScaler.html
		CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
		canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPhysicalSize;
		canvasScaler.physicalUnit = CanvasScaler.Unit.Points;
	}

	public GameObject initCanvas2(GameObject parent) {
		GameObject canvasObject = new GameObject("Canvas");
		canvasObject.transform.SetParent(parent.transform);
		initCanvas (canvasObject);
		return canvasObject;
	}

}