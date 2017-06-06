using UnityEngine;

namespace MDUI
{
    public class MDTypographyManager : MonoBehaviour
    {

        // fields visible in Unity3d inspector
        public Font font;

        public MDTypography subhead = new MDTypography(16, FontStyle.Normal);
        public MDTypography title = new MDTypography(20, FontStyle.Bold);
        public MDTypography headline = new MDTypography(24, FontStyle.Normal);

        public MDTypography caption = new MDTypography(12, FontStyle.Normal);
        public MDTypography button = new MDTypography(14, FontStyle.Bold);
        public MDTypography body1 = new MDTypography(14, FontStyle.Normal);
        public MDTypography body2 = new MDTypography(14, FontStyle.Bold);

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

