using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(ChangeColorToggle))]
public class ChangeColorToggleEditor : ToggleEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_isOnColor"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_isOffColor"));
        serializedObject.ApplyModifiedProperties();
    }
}