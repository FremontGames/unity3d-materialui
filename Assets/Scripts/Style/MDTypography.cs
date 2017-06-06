using UnityEngine;

namespace MDUI
{
    [System.Serializable]
    public class MDTypography : System.Object
    {
        public int fontSize;
        public FontStyle fontStyle;

        public MDTypography(int _fontSize, FontStyle _fontStyle)
        {
            fontSize = _fontSize;
            fontStyle = _fontStyle;
        }
    }
}
