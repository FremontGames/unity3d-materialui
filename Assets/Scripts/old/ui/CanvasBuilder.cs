using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasBuilder
{
	Transform _parent;

	public GameObject build ()
	{
		GameObject obj = Builder.build (_parent, 5, "Canvas");

		// RectTransform canvasTrans = obj.AddComponent<RectTransform> ();

		// Canvas
		Canvas canvas = obj.AddComponent<Canvas> ();
		// http://docs.unity3d.com/Manual/UICanvas.html
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		canvas.pixelPerfect = true;
		// Canvas Scaler
		// http://docs.unity3d.com/ScriptReference/UI.CanvasScaler.html
		CanvasScaler canvasScaler = obj.AddComponent<CanvasScaler> ();
		/*		canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPhysicalSize;
		canvasScaler.physicalUnit = CanvasScaler.Unit.Points;
*/
		canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		canvasScaler.referenceResolution = new Vector2 (800, 600);
		obj.AddComponent<GraphicRaycaster> ();
		return obj;
	}

	public static CanvasBuilder parent (Transform obj)
	{
		CanvasBuilder b = new CanvasBuilder ();
		b._parent = obj;
		return b;
	}


}

