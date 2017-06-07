using UnityEngine;

namespace MDUI.Style
{
    public class MDTheme
    {
        // fields visible in Unity3d inspector
        public string primaryPalette = "indigo";
        public string accentPalette = "pink";
        public string warnPalette = "red";
        public string backgroundPalette = "grey";

        public Color color = new Color(0, 0, 0, 0.87f);

        private static MDTheme singleton = null;
        public static MDTheme get()
        {
            if (singleton == null)
                singleton = new MDTheme();
            return singleton;
        }

    }
}