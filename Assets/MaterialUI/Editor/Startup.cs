// https://support.unity3d.com/hc/en-us/articles/208456906-Excluding-Scripts-and-Assets-from-builds
#if (UNITY_EDITOR)

using UnityEditor;
using MDUI.Editor;
using MDUI.Component;

// http://docs.unity3d.com/Manual/RunningEditorCodeOnLaunch.html
[InitializeOnLoad]
public class Startup
{
	// https://docs.unity3d.com/ScriptReference/MenuItem.html

	[MenuItem ("GameObject/UI-MD/Text", false, 1)]
	static void CreateCustomGameObject_Text (MenuCommand menuCommand)
	{
		MDComponentFactory.Create<MDText> (menuCommand, "Text", (MDText comp) => {
		});
	}

	[MenuItem ("GameObject/UI-MD/Button/Flat", false, 2)]
	static void CreateCustomGameObject_Button_Flat (MenuCommand menuCommand)
	{
		MDComponentFactory.Create<MDButton> (menuCommand, "Flat Button", (MDButton comp) => {
			comp.type = MDButtonType.Flat;
			comp.state = MDButtonState.Normal;
		});
	}

	[MenuItem ("GameObject/UI-MD/Button/Raised", false, 2)]
	static void CreateCustomGameObject_Button_Raised (MenuCommand menuCommand)
	{
		MDComponentFactory.Create<MDButton> (menuCommand, "Raised Button", (MDButton comp) => {
			comp.type = MDButtonType.Raised;
			comp.state = MDButtonState.Normal;
		});
	}
	/*
    [MenuItem("GameObject/UI-MD/Button/Fab", false, 2)]
    static void CreateCustomGameObject_Button_Fab(MenuCommand menuCommand)
    {
		MDButton comp = MDButton.create<MDButton> (menuCommand, "Fab Button");
		comp.type = MDButtonType.Fab;
		comp.state = MDButtonState.Normal;
    }

    [MenuItem("GameObject/UI-MD/Button/Icon", false, 2)]
    static void CreateCustomGameObject_Button_Icon(MenuCommand menuCommand)
    {
		MDButton.create (menuCommand, "Icon Button", MDButtonType.Icon);
		comp.type = MDButtonType.Fab;
		comp.state = MDButtonState.Normal;
    }
*/
	[MenuItem ("GameObject/UI-MD/Layout", false, 5)]
	static void CreateCustomGameObject_Layout (MenuCommand menuCommand)
	{
		MDComponentFactory.Setup_Layout (menuCommand);
	}

	// TODO add component menu items


}

#endif
