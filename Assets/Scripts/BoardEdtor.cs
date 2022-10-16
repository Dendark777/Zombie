using UnityEditor;
using UnityEngine;

namespace Scripts.BoardLogic
{
    [CustomEditor(typeof(BoardGrid))]

    public class BoardEdtor : Editor
    {
        public override void OnInspectorGUI()
        {
            var grid = target as BoardGrid;

            DrawDefaultInspector();

            if (GUILayout.Button("Создать"))
            {
               
            }        
        }

    }
}

