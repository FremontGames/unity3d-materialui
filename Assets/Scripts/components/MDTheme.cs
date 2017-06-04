using UnityEngine;
using System.Collections;
namespace MDUI
{
    public class MDTheme
    {
        private static MDTheme singleton = null;
        public static MDTheme get()
        {
            if (singleton == null)
                singleton = new MDTheme();
            return singleton;
        }

        public Font font;
        public int fontSize;
        public Color color;
        public FontStyle fontStyle;

        MDTheme()
        {
            font = Resources.Load<Font>("Fonts/Roboto-Regular");
            fontSize = 14;
            fontStyle = FontStyle.Normal;
            color = new Color(0, 0, 0, 0.87f);
        }

    }
}