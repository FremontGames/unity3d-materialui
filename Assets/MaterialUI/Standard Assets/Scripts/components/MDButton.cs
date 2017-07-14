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
			SetColor ();
			if (editorUpdateChilds)
				UpdateChilds ();
		}

		private void SetSize ()
		{
			RectTransform cmp = gameObject.GetComponent<RectTransform> ();
			if (null == cmp) {
				cmp = gameObject.AddComponent<RectTransform> ();
			}
			if (type == MDButtonType.Icon) {
				MDComponentUtils.SetSize (cmp, new Vector2 (30, 30));
			} else if (type == MDButtonType.Fab) {
				MDComponentUtils.SetSize (cmp, new Vector2 (80, 80));
			} else {
				MDComponentUtils.SetSize (cmp, new Vector2 (260, 80));
			}		
		}

		private void SetBackground ()
		{
			Image cmp = gameObject.GetComponent<Image> ();
			if (null == cmp) {
				cmp = gameObject.AddComponent<Image> ();
			}
			// type
			if (type == MDButtonType.Flat) {
				cmp.enabled = false;
			} else if (type == MDButtonType.Raised) {
				cmp.enabled = true;
				MDComponentUtils.init (cmp, "Sprites/button_raised_bkg");
			} else if (type == MDButtonType.Fab) {
				cmp.enabled = true;
				MDComponentUtils.init (cmp, "Sprites/button_fab_bkg");
			}
			/*
			// style
			if (state == MDButtonState.Normal) {
				cmp.color = new Color (0.95f, 0.95f, 0.95f, 1f);
			} else if (state == MDButtonState.Primary) {
				cmp.color = new Color (0.2f, 0.5f, 0.9f, 1f);
			} else if (state == MDButtonState.Disabled) {
				cmp.color = new Color (0.8f, 0.8f, 0.8f, 1f);
			} else if (state == MDButtonState.Warn) {
				cmp.color = new Color (1.0f, 0.3f, 0.1f, 1f);
			}
			*/
		}
		private void SetColor ()
		{
			// http://docs.unity3d.com/Manual/script-Button.html
			Button cmp = gameObject.GetComponent<Button> ();
			if (null == cmp) {
				cmp = gameObject.AddComponent<Button> ();
			}
			// http://docs.unity3d.com/Manual/script-SelectableTransition.html
			cmp.transition = Selectable.Transition.ColorTint;
			// http://docs.unity3d.com/ScriptReference/Color32.html
			ColorBlock cb = cmp.colors;
			if (state == MDButtonState.Normal) {
				cb.normalColor =      new Color (0.95f, 0.95f, 0.95f, 1f);
				cb.highlightedColor = cb.normalColor;
				cb.pressedColor =     new Color (0.7f, 0.7f, 0.7f, 1f);
			} else if (state == MDButtonState.Primary) {
				cb.normalColor = new Color (0.2f, 0.5f, 0.9f, 1f);
			} else if (state == MDButtonState.Disabled) {
				cb.normalColor = new Color (0.8f, 0.8f, 0.8f, 1f);
			} else if (state == MDButtonState.Warn) {
				cb.normalColor = new Color (1.0f, 0.3f, 0.1f, 1f);
			}
			cb.colorMultiplier = 1f;
			cb.fadeDuration = 0.1f;
			cmp.colors = cb;
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