using UnityEngine;
using UnityEngine.UI;

namespace MDUI.Component
{
    public enum MDButtonType
    {
        Flat, Raised, Fab, Icon
    }
    public enum MDButtonState
    {
        Normal, Primary, Disabled, Warn
    }
	public class MDButton : MDComponent
	{   
        public MDButtonType type = MDButtonType.Flat;
        public MDButtonState state = MDButtonState.Normal;

		public override void init() 
		{
			if (type == MDButtonType.Raised)
			{
				Image img = gameObject.AddComponent<Image>();
				init(img, "Sprites/button_raised_bkg");
				// TODO STATE
				// http://answers.unity3d.com/questions/1121691/how-to-modify-images-coloralpha.html
				img.color = new Color(0.5f, 0.5f, 0.5f, 1f); // Set to opaque gray
			}
			else if (type == MDButtonType.Fab)
			{
				Image img = gameObject.AddComponent<Image>();
				init(img, "Sprites/button_fab_bkg");
			}
			if (type == MDButtonType.Flat || type == MDButtonType.Raised)
			{
				GameObject obj = new GameObject("Text");
				Text txt = obj.AddComponent<Text>();
				txt.text = "Button";
				txt.alignment = TextAnchor.MiddleCenter;
				obj.AddComponent<MDText>();
				obj.transform.SetParent(gameObject.transform);
			}
		}

		public override void apply ()
		{
			RectTransform comp = this.GetComponentInChildren<RectTransform> ();
			if(type == MDButtonType.Icon)
			{
				SetSize(comp, new Vector2(30, 30));
			}
			else if (type == MDButtonType.Fab)
			{
				SetSize(comp, new Vector2(80, 80));
			}
			else
			{
				SetSize(comp, new Vector2(260, 80));
			}
		}

        [System.Obsolete]
        static void SetSize(RectTransform trans, Vector2 size)
        {
            Vector2 currSize = trans.rect.size;
            Vector2 sizeDiff = size - currSize;
            trans.offsetMin = trans.offsetMin -
            new Vector2(sizeDiff.x * trans.pivot.x,
                sizeDiff.y * trans.pivot.y);
            trans.offsetMax = trans.offsetMax +
            new Vector2(sizeDiff.x * (1.0f - trans.pivot.x),
                sizeDiff.y * (1.0f - trans.pivot.y));
        }

		[System.Obsolete]
		static void init(Image image, string resource)
		{
			Texture2D tex = Resources.Load<Texture2D>(resource);

			// IF scliced
			// http://docs.unity3d.com/ScriptReference/Sprite.Create.html
			float pixelsPerUnit = 100.0f;
			uint extrude = 0;
			SpriteMeshType meshType = SpriteMeshType.Tight;
			// http://docs.unity3d.com/450/Documentation/ScriptReference/Sprite-border.html
			// Vector4 border = Vector4.zero;
			// http://docs.unity3d.com/ScriptReference/Vector4.html
			Vector4 border = new Vector4(10, 10, 10, 10);
			image.type = Image.Type.Sliced;

			// ELSE
			// image.type = Image.Type.Simple;

			image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height),
				new Vector2(0.5f, 0.5f), pixelsPerUnit, extrude, meshType,
				border);
		}
    }

}