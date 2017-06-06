// https://support.unity3d.com/hc/en-us/articles/208456906-Excluding-Scripts-and-Assets-from-builds
#if (UNITY_EDITOR)

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using MDUI;

// http://docs.unity3d.com/Manual/RunningEditorCodeOnLaunch.html
[InitializeOnLoad]
public class Startup
{

    static Startup()
    {
        Debug.Log("----------------------------");
        Debug.Log("EditorStartup:Up and running");
    }

    static private GameObject getParent(MenuCommand menuCommand)
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

    static private string checkName(GameObject parent, string name)
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

    [MenuItem("GameObject/UI-MD/Layout", false, 10)]
    static void CreateCustomGameObject_Layout(MenuCommand menuCommand)
    {
        GameObject parent = getParent(menuCommand);
        string name = checkName(parent, "Layout");

        GameObject go = new GameObject(name);
        go.AddComponent<MDLayout>();

        GameObjectUtility.SetParentAndAlign(go, parent);
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }

    // https://docs.unity3d.com/ScriptReference/MenuItem.html
    [MenuItem("GameObject/UI-MD/Text", false, 10)]
    static void CreateCustomGameObject_Text(MenuCommand menuCommand)
    {
        GameObject parent = getParent(menuCommand);
        string name = checkName(parent, "Text");

        GameObject go = new GameObject(name);
        Text text = go.AddComponent<Text>();
        text.text = "New Text";
        go.AddComponent<MDText>();

        GameObjectUtility.SetParentAndAlign(go, parent);
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
    [MenuItem("GameObject/UI-MD/Button/Flat", false, 10)]
    static void CreateCustomGameObject_Button_Flat(MenuCommand menuCommand)
    {

    }

    [MenuItem("GameObject/UI-MD/Button/Raised", false, 10)]
    static void CreateCustomGameObject_Button_Raised(MenuCommand menuCommand)
    {
        GameObject parent = getParent(menuCommand);
        string name = checkName(parent, "Button");

        GameObject go = new GameObject(name);
        Image img = go.AddComponent<Image>();
        init(img, "button_bkg");
        go.AddComponent<Button>();
        go.AddComponent<MDButton>();

        GameObject go2 = new GameObject("Text");
        Text text = go2.AddComponent<Text>();
        text.text = "Button";
        text.alignment = TextAnchor.MiddleCenter;

        go2.AddComponent<MDText>();

        go2.transform.SetParent(go.transform);

        GameObjectUtility.SetParentAndAlign(go, parent);
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }

    // TODO add component menu items

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

#endif
