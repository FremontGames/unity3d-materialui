using UnityEngine;
using System.Collections.Generic;

namespace MDUI.Style
{
	public enum MDThemeColorType
	{
		light,
		dark
	}

	public class MDTheme 
	{
		// fields visible in Unity3d inspector
		public string[,] primaryPalette = new string[, ] { 
				{ "50", "#fafafa" },
				{ "100", "#f5f5f5" },
				{ "200", "#eeeeee" },
				{ "300", "#e0e0e0" },
				{ "400", "#bdbdbd" },
				{ "500", "#9e9e9e" },
				{ "600", "#757575" },
				{ "700", "#616161" },
				{ "800", "#424242" },
				{ "900", "#212121" },
				{ "A100", "#ffffff" },
				{ "A200", "#000000" },
				{ "A400", "#303030" },
				{ "A700", "#616161" },
				{ "contrastDefaultColor", "dark" },
				{ "contrastLightColors", "600 700 800 900 A200 A400 A700" }

		};
		public Color primaryPalette50 = new Color (0.9f, 0.95f, 1.0f);
		public Color primaryPalette500 = new Color (0.1f, 0.6f, 0.95f);
		public Color primaryPaletteA100 = new Color (0.5f, 0.7f, 1.0f);
		public Color primaryPaletteA200 = new Color (0.3f, 0.5f, 1.0f);
		public MDThemeColorType primaryPaletteContrastDefaultColor = MDThemeColorType.light;

		public string accentPalette = "green";
		public Color accentPalette50 = new Color (0.9f, 0.95f, 0.9f);
		public Color accentPalette500 = new Color (0.3f, 0.7f, 0.3f);
		public MDThemeColorType accentPaletteContrastDefaultColor = MDThemeColorType.dark;

		public string warnPalette = "red";
		public Color warnPalette50 = new Color (1.0f, 0.9f, 0.9f);
		public Color warnPalette500 = new Color (1.0f, 0.3f, 0.1f);
		public MDThemeColorType warnPaletteContrastDefaultColor = MDThemeColorType.light;

		public string backgroundPalette = "grey";
		public Color backgroundPalette50 = new Color (0.95f, 0.95f, 0.95f);
		public Color backgroundPalette500 = new Color (0.6f, 0.6f, 0.6f);
		public MDThemeColorType backgroundPaletteContrastDefaultColor = MDThemeColorType.dark;

		private static MDTheme singleton = null;

		public static MDTheme get ()
		{
			if (singleton == null)
				singleton = new MDTheme ();
			return singleton;
		}

	}
}