using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Menu2 : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
		GameObject canvasObject = new GameObject("Canvas");
		canvasObject.transform.SetParent(this.transform);
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

		{
			int x = 0;
			int y = 50;
			int w = 160;
			int h = 30;

			GameObject buttonObject = new GameObject("Button");
			buttonObject.transform.SetParent(canvasObject.transform);
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

			// Image
			Image image = buttonObject.AddComponent<Image>();
			Texture2D tex = Resources.Load<Texture2D>("button_bkg");

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

			// Button Script TODO

			{
				x = 0;
				y = 0;
				w = 0;
				h = 0;

				GameObject textObject = new GameObject("Text");
				textObject.transform.SetParent(buttonObject.transform);

				RectTransform trans = textObject.AddComponent<RectTransform>();
				trans.sizeDelta.Set(w, h);
				trans.anchoredPosition3D = new Vector3(0, 0, 0);
				trans.anchoredPosition = new Vector2(x, y);
				trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				trans.localPosition.Set(0, 0, 0);

				CanvasRenderer renderer = textObject.AddComponent<CanvasRenderer>();

				Text text = textObject.AddComponent<Text>();
				text.supportRichText = true;
				text.text = "message";
				text.fontSize = 14;
				text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
				text.alignment = TextAnchor.MiddleCenter;
				text.horizontalOverflow = HorizontalWrapMode.Overflow;
				text.color = Color.white;

			}

		}
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

}

