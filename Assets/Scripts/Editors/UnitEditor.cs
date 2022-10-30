using Assets.Scripts.MonoBehaviors.Cells;
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
            var gameboardData = GameboardData.Instance;
            gameboardData.Units = FindObjectsOfType<Unit>().ToList();
            foreach (var item in gameboardData.Units)
            {
                item.FindCell();
                EditorUtility.SetDirty(item);
            }
            AssetDatabase.SaveAssets(); 
        }
    }
}
