using UnityEngine;
using UnityEngine.UI;

namespace MDUI.Component
{
	public enum MDButtonType
	{
		Flat,
		Raised,
		Fab,
		Icon
	}

	public enum MDButtonState
	{
		Normal,
		Primary,
		Disabled,
		Warn
	}

	public class MDButton : MDComponent
	{
		public MDButtonType type;
		public MDButtonState state;

		void OnValidate ()
		{
			SetSize ();
			SetBackground ();
			if (editorUpdateChilds)
				UpdateChilds ();
		}

		private void SetSize ()
		{
			RectTransform comp = gameObject.GetComponent<RectTransform> ();
			if (null == comp) {
				comp = gameObject.AddComponent<RectTransform> ();
			}
			if (type == MDButtonType.Icon) {
				MDComponentUtils.SetSize (comp, new Vector2 (30, 30));
			} else if (type == MDButtonType.Fab) {
				MDComponentUtils.SetSize (comp, new Vector2 (80, 80));
			} else {
				MDComponentUtils.SetSize (comp, new Vector2 (260, 80));
			}		
		}

		private void SetBackground ()
		{
			Image img = gameObject.GetComponent<Image> ();
			if (null == img) {
				img = gameObject.AddComponent<Image> ();
			}
			// type
			if (type == MDButtonType.Flat) {
				img.enabled = false;
			} else if (type == MDButtonType.Raised) {
				img.enabled = true;
				MDComponentUtils.init (img, "Sprites/button_raised_bkg");
			} else if (type == MDButtonType.Fab) {
				img.enabled = true;
				MDComponentUtils.init (img, "Sprites/button_fab_bkg");
			}
			// style
			if (state == MDButtonState.Normal) {
				img.color = new Color (0.95f, 0.95f, 0.95f, 1f);
			} else if (state == MDButtonState.Primary) {
				img.color = new Color (0.2f, 0.5f, 0.9f, 1f);
			} else if (state == MDButtonState.Disabled) {
				img.color = new Color (0.8f, 0.8f, 0.8f, 1f);
			} else if (state == MDButtonState.Warn) {
				img.color = new Color (1.0f, 0.3f, 0.1f, 1f);
			}
			
		}

		public override void Create ()
		{	
			CreateChilds ();
			OnValidate ();
		}

		private void UpdateChilds ()
		{
			Text txt = gameObject.GetComponentInChildren<Text> ();
			// style
			if (state == MDButtonState.Normal) {
				txt.color = new Color (0.1f, 0.1f, 0.1f, 1f);
			} else if (state == MDButtonState.Primary) {
				txt.color = new Color (1.0f, 1.0f, 1.0f, 1f);
			} else if (state == MDButtonState.Disabled) {
				txt.color = new Color (0.5f, 0.5f, 0.5f, 1f);
			} else if (state == MDButtonState.Warn) {
				txt.color = new Color (1.0f, 1.0f, 1.0f, 1f);
			}
		}

		private void CreateChilds ()
		{
			if (type == MDButtonType.Flat || type == MDButtonType.Raised) {
				GameObject obj = MDComponent.Create<MDText> ("Text", (MDText comp) => {
				});
				// txt.alignment = TextAnchor.MiddleCenter;
				obj.transform.SetParent (gameObject.transform);

				RectTransform xx = obj.GetComponent<RectTransform> ();
				MDComponentUtils.SetSize (xx, new Vector2 (260, 80));

			}
		}
	}

}