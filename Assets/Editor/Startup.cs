// https://support.unity3d.com/hc/en-us/articles/208456906-Excluding-Scripts-and-Assets-from-builds
#if (UNITY_EDITOR)

using UnityEditor;
using MDUI.Editor;

// http://docs.unity3d.com/Manual/RunningEditorCodeOnLaunch.html
[InitializeOnLoad]
public class Startup
{

    // https://docs.unity3d.com/ScriptReference/MenuItem.html

    [MenuItem("GameObject/UI-MD/Text", false, 1)]
    static void CreateCustomGameObject_Text(MenuCommand menuCommand)
    {
        MDComponentFactory.Text(menuCommand);
    }

    [MenuItem("GameObject/UI-MD/Button/Flat", false, 2)]
    static void CreateCustomGameObject_Button_Flat(MenuCommand menuCommand)
    {
        MDComponentFactory.Flat(menuCommand);
    }

    [MenuItem("GameObject/UI-MD/Button/Raised", false, 3)]
    static void CreateCustomGameObject_Button_Raised(MenuCommand menuCommand)
    {
        MDComponentFactory.Raised(menuCommand);
    }

    [MenuItem("GameObject/UI-MD/Layout", false, 4)]
    static void CreateCustomGameObject_Layout(MenuCommand menuCommand)
    {
        MDComponentFactory.Layout(menuCommand);
    }

    // TODO add component menu items


}

#endif
