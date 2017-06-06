using UnityEngine;
using UnityEditor;
using System.Collections;

namespace MDUI
{
    // https://docs.unity3d.com/Manual/editor-PropertyDrawers.html

    [CustomPropertyDrawer(typeof(MDTypography))]
    public class MDTypographyDrawer : PropertyDrawer
    {
        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            Rect fontSizeRect = new Rect(position.x, position.y, 30, position.height);
            Rect fontStyleRect = new Rect(position.x + 35, position.y, 50, position.height);

            EditorGUI.PropertyField(fontSizeRect, property.FindPropertyRelative("fontSize"), GUIContent.none);
            EditorGUI.PropertyField(fontStyleRect, property.FindPropertyRelative("fontStyle"), GUIContent.none);

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}