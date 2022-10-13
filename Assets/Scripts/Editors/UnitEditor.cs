using Assets.Scripts.MonoBehaviors.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editors
{
    [CustomEditor(typeof(Unit))]
    public class UnitEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var unit = target as Unit;
            DrawDefaultInspector();
            if (GUILayout.Button("Initialize"))
            {
                unit.FindCell();
            }
            if (GUILayout.Button("Next Item"))
            {
                unit.NextItem();
            }
        }
        [MenuItem("Tools/Initialize units")]
        private static void InitializeUnits()
        {
            foreach (var item in FindObjectsOfType<Unit>())
            {
                item.FindCell();
                EditorUtility.SetDirty(item);
            }
            AssetDatabase.SaveAssets(); 
        }
    }
}
