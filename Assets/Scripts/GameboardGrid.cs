using Assets.Scripts.MonoBehaviors.Cells;
using Assets.Scripts.SateMachines.Cells;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class GameboardGrid : MonoBehaviour
{
    [SerializeField] private Vector2Int _size;
    [SerializeField] private float _spacing;
    [SerializeField] private Cell _prefab;
    [SerializeField] private Transform _root;
    [SerializeField] private List<Cell> _cells;

    public List<Cell> Cells => _cells;

    private void Awake()
    {
        new GameboardData().GetInstance().Cells = Cells;
        GameManager.Instance.Cells = _cells;
    }

    [ContextMenu("Create")]
    public void Create()
    {
        Clear();
        for (int x = 0; x < _size.x; x++)
        {
            for (int y = 0; y < _size.y; y++)
            {
                Vector3 position = new Vector3(x * _spacing, y * _spacing);
                Cell cell = Instantiate(_prefab, position + _root.position, Quaternion.identity, _root);
                cell.Initialize(new Vector2Int(x, y));
                _cells.Add(cell);
            }
        }
        SetNeighbours();
    }

    public void SetNeighbours()
    {
        int x;
        int y;
        foreach (var cell in _cells)
        {
            x = cell.Position.x;
            y = cell.Position.y;
            cell.SetNeighbours(_cells.Where(c => (c.Position.x == x - 1 && c.Position.y == y) ||
                                                 (c.Position.x == x + 1 && c.Position.y == y) ||
                                                 (c.Position.x == x && c.Position.y == y - 1) ||
                                                 (c.Position.x == x && c.Position.y == y + 1)).ToList());
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        for (int i = 0; i < _cells.Count;)
        {
            DestroyImmediate(_cells[i].GameObject);
            _cells.RemoveAt(i);
        }
        _cells.Clear();
    }
}
