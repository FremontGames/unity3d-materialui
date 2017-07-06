using System;
using UnityEngine;
using UnityEngine.UI;

namespace MDUI.Component
{
	public class MDComponentUtils
	{
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

		public static void init (Image image, string resource)
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

	}
	
}

