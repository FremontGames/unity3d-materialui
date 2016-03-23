using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasBuilder
{
	Transform _parent;

	public CanvasBuilder (Transform parent)
	{
		_parent = parent;
	}

	public GameObject build ()
	{
		GameObject canvasObject = new GameObject ("Canvas");
		canvasObject.transform.SetParent (_parent);
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
*/
		canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		canvasScaler.referenceResolution = new Vector2 (800, 600);
		GraphicRaycaster canvasRayc = canvasObject.AddComponent<GraphicRaycaster> ();
		return canvasObject;
	}

	private const int LayerUI = 5;

}

