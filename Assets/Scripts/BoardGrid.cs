using System.Collections.Generic;
using UnityEngine;
using Zenject;

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

        private readonly BoardFactory _factory = new();

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
            Clear();

            _cells = _factory.Create(_prefab, _size, _spacing, _root);
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

    public class BoardFactory : IFactory <Cell, Vector2Int, float, Transform, List<Cell>>
    {
        public List<Cell> Create(Cell prefab, Vector2Int size, float spacing, Transform root) 
        {
            List<Cell> cells = new();

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Vector3 position = new(x * spacing, y * spacing);
                    Cell cell = Object.Instantiate(prefab, position + root.position, Quaternion.identity, root);
                    cell.Initialize(new Vector2Int(x, y));
                    cells.Add(cell);
                }
            }

            return cells;
        }
    }

}


