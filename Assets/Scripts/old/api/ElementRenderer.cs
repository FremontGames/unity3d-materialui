using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace DFREMONT.UI
{
	// https://unity3d.com/learn/tutorials/topics/user-interface-ui
	public class ElementRenderer : MonoBehaviour
	{
		public void start (Element parentElm, Transform parent, float x, float y, float w, float h)
		{
			Debug.Log ("x,y w,h = "+x+","+y+" "+w+","+h);
			GameObject cc = UIFactory.CreateElement (parent, x, y, w, h);
			if (parentElm._childs.Length > 0) {
				float perc = 1.0f / parentElm._childs.Length;
				for (int i = 0; i < parentElm._childs.Length; i++) {
					Element e = parentElm._childs [i];
					if (parentElm._attributs.ContainsKey("layout"))
						start (e, cc.transform,  0, i*h*perc, w, h*perc);
					else
						start (e, cc.transform, i*w*perc, 0, w*perc, h);
				}
			}
		}

		public void start2 (Element arg) {
			GameObject content = UIFactory.CreateCanvas (null);
			GameObject panel = UIFactory.CreatePanel (content.transform);
			GameObject t1 = UIFactory.CreateText (panel.transform, 0, 100, 160, 50, "Message2", 32);


			/*
			GameObject t2 = UIFactory.CreateText (panel.transform, 0, 0, 160, 50, "Are you sure, you want to exit?", 24);
			GameObject b1 = UIFactory.CreateButton (panel.transform, 0, -100, 160, 50, "Yes", null);
			GameObject b2 = UIFactory.CreateButton (panel.transform, 0, -200, 160, 50, "No", null);
			*/
			log ("content", content);
			log ("panel", panel);
 			log ("t1", t1);
			/*
			log ("t2", t2);
			log ("b1", b1);
			log ("b2", b2);
*/
			/*
			Debug.Log ("ElementRenderer:start (begin) =========================");
			GameObject obj = new GameObject ("root");
			// http://docs.unity3d.com/Manual/UICanvas.html
			Canvas canvas = obj.AddComponent<Canvas> ();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			canvas.pixelPerfect = true;
			// http://docs.unity3d.com/ScriptReference/UI.CanvasScaler.html
			CanvasScaler canvasScaler = obj.AddComponent<CanvasScaler> ();
			canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			canvasScaler.referenceResolution = new Vector2 (800, 600);
			obj.AddComponent<GraphicRaycaster> ();


			// Debug.Log ("Screen w,h "+w+","+h);

			// RectTransform trans = obj.AddComponent<RectTransform> ();
			*/
			float perc = 1.0f/arg._childs.Length;
			RectTransform rt = (RectTransform) panel.transform;
			float x = rt.position.x;
			float w = rt.rect.width;
			float x0 = x - (w/2);
			Debug.Log ("x="+x+" x0="+x0+" w="+w);

			Debug.Log ("perc="+ perc);
			for (int i = 0; i < arg._childs.Length; i++) {
				Element e = arg._childs[i];
				// GameObject obj = new GameObject (e._attributs["id"]);
				/*GameObject t = UIFactory.CreatePanel (panel.transform, -x+(w*perc/2)+i*(w*perc), 200, w*perc, 50, 
					"Message3", 32);*/

				GameObject t0 = UIFactory.CreateCanvas (panel.transform);
				GameObject t = UIFactory.CreatePanel (t0.transform);
				t.transform.localScale = new Vector3 (perc, 1.0f, 1.0f);
				t.transform.position = new Vector2 (-x+(w*perc/2)+i*(w*perc),200);
				log ("t", t);

				// t.transform.localPosition = new Vector3 (2, t.transform.localPosition.y, t.transform.localPosition.z);
				for (int y = 0; y < e._childs.Length; y++) {
					// UIFactory.CreatePanel (t.transform);
				}
			}
			/*
			obj.transform.SetParent (_parent);
			obj.layer = 0;

			GameObject view = Instantiate(obj) as GameObject;
			scaler(view);
			view.AddComponent<MDInjecter> ();

			Debug.Log ("ElementRenderer:start (end) ===========================");
			*/
			// log ("_parent", _parent);

		}

		void log(string id, GameObject obj) {
			RectTransform rt = (RectTransform) obj.transform;
			float x = rt.position.x;
			float y = rt.position.y;
			float w = rt.rect.width;
			float h = rt.rect.height;
			float wp = rt.localScale.x;
			float hp = rt.localScale.y;
			float x0 = x - (w/2);
			float y0 = y - (h/2);
			Debug.Log (id+" ("+x0+","+y0+") ("+w+","+h+") ("+wp+","+hp+")");
		}

		void scaler(GameObject obj) {
			if (obj.GetComponent<Canvas> () == null) {

				Canvas canvas = obj.AddComponent<Canvas> ();
				// http://docs.unity3d.com/Manual/UICanvas.html
				canvas.renderMode = RenderMode.ScreenSpaceOverlay;
				canvas.pixelPerfect = true;
				// Canvas Scaler
				// http://docs.unity3d.com/ScriptReference/UI.CanvasScaler.html
				CanvasScaler canvasScaler = obj.AddComponent<CanvasScaler> ();
				canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
				canvasScaler.referenceResolution = new Vector2 (800, 600);
				canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Shrink;
				obj.AddComponent<GraphicRaycaster> ();
			}
		}
	}
}
