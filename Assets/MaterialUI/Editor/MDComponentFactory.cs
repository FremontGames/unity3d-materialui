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
		public static GameObject Create<T> (MenuCommand menuCommand, string defaultName, Action<T> vars) where T:MDComponent{
			GameObject parent = getParent(menuCommand);
			string name = checkNameExists(parent, defaultName);

			GameObject obj = MDComponent.Create<T> (name, vars);

			GameObjectUtility.SetParentAndAlign(obj, parent);
			Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
			Selection.activeObject = obj;

			return obj;
		}

		static string checkNameExists(GameObject parent, string name)
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
			
        public static void Setup_Layout(MenuCommand menuCommand)
        {
            GameObject parent = getParent(menuCommand);
			string name = checkNameExists(parent, "Layout");

            GameObject go = new GameObject(name);
            go.AddComponent<MDLayout>();

            GameObjectUtility.SetParentAndAlign(go, parent);
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
    }
}
#endif
