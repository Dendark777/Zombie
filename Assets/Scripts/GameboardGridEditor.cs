using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameboardGrid))]
public class GameboardGridEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var grid = target as GameboardGrid;
        DrawDefaultInspector();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Create"))
        {
            grid.Create();
        }
        if (GUILayout.Button("Clear"))
        {
            grid.Clear();
        }
        EditorGUILayout.EndHorizontal();

    }
}
