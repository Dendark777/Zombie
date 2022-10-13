using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editors
{
    [CustomEditor(typeof(ItemDatabase))]
    public class ItemDBEditor : Editor
    {
        private ItemDatabase _database;
        private void Awake()
        {
            _database = (ItemDatabase)target;
        }

        public override void OnInspectorGUI()
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Удалить всё"))
            {
                _database.ClearDataBase();
            }
            if (GUILayout.Button("Удалить"))
            {
                _database.RemoveCurrentItem();
            }
            if (GUILayout.Button("Добавить"))
            {
                _database.AddItem();
            }
            if (GUILayout.Button("<="))
            {
                _database.GetPrev();
            }
            if (GUILayout.Button("=>"))
            {
                _database.GetNext();
            }

            GUILayout.EndHorizontal();
            base.OnInspectorGUI();
        }
    }
}
