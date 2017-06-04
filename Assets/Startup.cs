// TODO exclude from build
using UnityEngine;
using UnityEngine.UI;
using MDUI;
using UnityEditor;

// http://docs.unity3d.com/Manual/RunningEditorCodeOnLaunch.html
[InitializeOnLoad]
public class Startup {

    static Startup()
	{
		Debug.Log("----------------------------");
		Debug.Log("EditorStartup:Up and running");
	}

    // https://docs.unity3d.com/ScriptReference/MenuItem.html

    [MenuItem("GameObject/UI-MD/Text", false, 10)]
    static void CreateCustomGameObject(MenuCommand menuCommand)
    {
        GameObject parent = Selection.activeTransform != null ? Selection.activeTransform.gameObject : menuCommand.context as GameObject;
        if(parent==null ||parent.GetComponentInParent<Canvas>() == null)
        {
            GameObject go2 = new GameObject("Canvas");
            Canvas canvas = go2.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            GameObjectUtility.SetParentAndAlign(go2, parent);
            parent = go2;
            // TODO NE PAS CREER DANS TEXT
        }

        string name = "Text";
        for(int i = 0;i < parent.transform.childCount; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            if (name == child.name)
                name = name + "(1)";
            // TODO incrementer
        }


        GameObject go = new GameObject(name);
        Text text = go.AddComponent<Text>();
        text.text = "New Text";
        go.AddComponent<MDText>();

        GameObjectUtility.SetParentAndAlign(go, parent);
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }

}

