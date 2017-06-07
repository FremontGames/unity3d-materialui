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
    public class MDButton : MonoBehaviour
    {
        // fields visible in Unity3d inspector
        public MDButtonType type = MDButtonType.Flat;
        public MDButtonState state = MDButtonState.Normal;

        // Use this for initialization
        void Start()
        {
            apply(this.GetComponentInChildren<RectTransform>());
        }

        // Update is called once per frame
        void Update()
        {

        }

        // Use this for editor reset component button
        void Reset()
        {
            apply(this.GetComponentInChildren<RectTransform>());
        }

        public void apply(RectTransform comp)
        {
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
        public static void SetSize(RectTransform trans, Vector2 size)
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
    }

}