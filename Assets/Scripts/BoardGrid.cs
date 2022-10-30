using System.Collections.Generic;
using UnityEngine;
//using Zenject;

namespace Scripts.BoardLogic
{
    public class BoardGrid : MonoBehaviour
    {
        [SerializeField] private Vector2Int _size;
        [SerializeField] private float _spacing;

        [Space]

        [SerializeField] private Cell _prefab;

        [Space]

        [SerializeField] private Transform _root;

        [Space]

        [SerializeField] private List<Cell> _cells;

        public List<Cell> Cells => _cells;

        private static BoardGrid _instance;
        public static BoardGrid Instance => _instance ??= FindObjectOfType<BoardGrid>();
        private void Awake()
        {
            if (_instance != null)
                Destroy(gameObject);

                _instance = this;
        }

        public static BoardGrid GetInstance() 
        {
            return _instance;
        } 



        private void OnValidate()
        {
            _size = new((int)Mathf.Clamp(_size.x, 0, Mathf.Infinity), (int)Mathf.Clamp(_size.y, 0, Mathf.Infinity));
            _spacing = Mathf.Clamp(_spacing, 0, Mathf.Infinity);

            if (_root == null)
            {
                _root = transform;
            }
        }

        [ContextMenu("Create")]
        public void Create()
        {
            int number = 0;
            Clear();
            for (int x = 0; x < _size.x; x++)
            {
                for (int y = 0; y < _size.y; y++)
                {
                    Vector3 position = new(x * _spacing, y * _spacing);
                    Cell cell = Object.Instantiate(_prefab, position + _root.position, Quaternion.identity, _root);
                    cell.Initialize(new Vector2Int(x, y), number);
                    _cells.Add(cell);
                    number++;
                }
            }

        }

        [ContextMenu("Очистить")]
        public void Clear()
        {
            for (int i = 0; i < _cells.Count;)
            {
                DestroyImmediate(_cells[i].GameObject);

                _cells.RemoveAt(i);
            }
        }
    }

}


