using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SGUIButton : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		texture (this.transform, "button_bkg2");
	}

	void texture (Transform go, string _texture)
	{
		if (!string.IsNullOrEmpty (_texture)) {
			Image image = go.gameObject.GetComponent<Image> ();
			Texture2D tex = Resources.Load<Texture2D> (_texture);
			if (tex != null) {
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


}

