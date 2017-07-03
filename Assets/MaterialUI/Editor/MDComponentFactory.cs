// https://support.unity3d.com/hc/en-us/articles/208456906-Excluding-Scripts-and-Assets-from-builds
#if (UNITY_EDITOR)

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using MDUI.Component;
using System;

namespace MDUI.Editor
{
    public class MDComponentFactory
    {
		public static void Create<T>(MenuCommand menuCommand, string name) where T:MDComponent
		{
			GameObject par = getParent(menuCommand);
			GameObject obj = create<T>(name, par);
			GameObjectUtility.SetParentAndAlign(obj, par);
			Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
			Selection.activeObject = obj;
		}

		static GameObject create <T> (string defaultName, GameObject parent) where T:MDComponent{
			string name = checkName(parent, defaultName);
			GameObject obj = new GameObject(name);
			MDComponent cmp = obj.AddComponent<T>();
			cmp.init ();
			cmp.apply ();
			return obj;
		}

        static string checkName(GameObject parent, string name)
        {
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                GameObject child = parent.transform.GetChild(i).gameObject;
                if (name == child.name)
                    name = name + " (1)";
                // TODO incrementer
            }
            return name;
        }

        static GameObject getParent(MenuCommand menuCommand)
        {
            GameObject parent = Selection.activeTransform != null ? Selection.activeTransform.gameObject : menuCommand.context as GameObject;
            if (parent == null || parent.GetComponentInParent<Canvas>() == null)
            {
                GameObject go2 = new GameObject("Canvas");
                Canvas canvas = go2.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                // SCALE
                // https://docs.unity3d.com/ScriptReference/SystemInfo-deviceType.html
                CanvasScaler scaler = go2.AddComponent<CanvasScaler>();
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                if (SystemInfo.deviceType == DeviceType.Handheld)
                    scaler.referenceResolution = new Vector2(640, 960);
                else if (SystemInfo.deviceType == DeviceType.Desktop)
                    scaler.referenceResolution = new Vector2(1280, 720);
                else if (SystemInfo.deviceType == DeviceType.Console)
                    scaler.referenceResolution = new Vector2(1920, 1080);
                else
                {
                    Debug.LogError("DeviceType is unknown.");
                    scaler.referenceResolution = new Vector2(1024, 1024);
                }
                // REFRESH
                GraphicRaycaster ray = go2.AddComponent<GraphicRaycaster>();

                // SET
                GameObjectUtility.SetParentAndAlign(go2, parent);
                parent = go2;
                // TODO NE PAS CREER DANS TEXT
                // TODO add Graphic Raycaster to animate
            }
            return parent;
        }

        public static void Setup_Button(MenuCommand menuCommand, MDButtonType type)
        {
            GameObject parent = getParent(menuCommand);
            string name = checkName(parent, "Button");

            GameObject go = new GameObject(name);
            go.AddComponent<Button>();

            MDButton md = go.AddComponent<MDButton>();
            md.type = type;

            if (type == MDButtonType.Raised)
            {
                Image img = go.AddComponent<Image>();
                init(img, "Sprites/button_raised_bkg");

                // TODO STATE
                // http://answers.unity3d.com/questions/1121691/how-to-modify-images-coloralpha.html
                img.color = new Color(0.5f, 0.5f, 0.5f, 1f); // Set to opaque gray

            }
            else if (type == MDButtonType.Fab)
            {
                Image img = go.AddComponent<Image>();
                init(img, "Sprites/button_fab_bkg");
            }

            if (type == MDButtonType.Flat || type == MDButtonType.Raised)
            {
                GameObject go2 = new GameObject("Text");
                Text text = go2.AddComponent<Text>();
                text.text = "Button";
                text.alignment = TextAnchor.MiddleCenter;
                go2.AddComponent<MDText>();
                go2.transform.SetParent(go.transform);
            }

            GameObjectUtility.SetParentAndAlign(go, parent);
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }

        public static void Setup_Layout(MenuCommand menuCommand)
        {
            GameObject parent = getParent(menuCommand);
            string name = checkName(parent, "Layout");

            GameObject go = new GameObject(name);
            go.AddComponent<MDLayout>();

            GameObjectUtility.SetParentAndAlign(go, parent);
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }

        public static void init(Image image, string resource)
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
#endif
