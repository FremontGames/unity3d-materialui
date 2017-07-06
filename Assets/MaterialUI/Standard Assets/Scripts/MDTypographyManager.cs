using UnityEngine;

namespace MDUI.Style
{
    public class MDTypographyManager
    {
        // fields visible in Unity3d inspector
        public Font font;
        public MDTypography subhead;
        public MDTypography title;
        public MDTypography headline;
        public MDTypography caption;
        public MDTypography button;
        public MDTypography body1;
        public MDTypography body2;

		MDTypographyManager() {
			subhead = new MDTypography(16, FontStyle.Normal);
			title = new MDTypography(20, FontStyle.Bold);
			headline = new MDTypography(24, FontStyle.Normal);
			caption = new MDTypography(12, FontStyle.Normal);
			button = new MDTypography(14, FontStyle.Bold);
			body1 = new MDTypography(14, FontStyle.Normal);
			body2 = new MDTypography(14, FontStyle.Bold);
		}

        // Use this for initialization
        void Start()
        {
            font = Resources.Load<Font>("Fonts/Roboto-Regular");
        }

        // Use this for editor reset component button
        void Reset()
        {
            Start();
        }

        private static MDTypographyManager singleton = null;
        public static MDTypographyManager get()
        {
            if (singleton == null)
            {
                singleton = new MDTypographyManager();
                singleton.Start();
            }
            return singleton;
        }
    }
}

