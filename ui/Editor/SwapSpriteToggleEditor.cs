using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(SwapSpriteToggle))]
public class SwapSpriteToggleEditor : ToggleEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_isOnSprite"));
        serializedObject.ApplyModifiedProperties();
    }
}