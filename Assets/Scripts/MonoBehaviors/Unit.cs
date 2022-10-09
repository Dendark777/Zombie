using Assets.Scripts.SateMachines.Cell;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private Vector2Int[] _moves;
    [SerializeField] private Vector2Int[] _attackMoves;


    [SerializeField] private Cell _cell;

    [Header("Gizmos")]
    [SerializeField] private Color _moveColor = Color.white;
    [SerializeField] private Color _attackColor = Color.white;
    [SerializeField] private Color _universalColor = Color.white;

    [SerializeField] private float _spacing;

    [Header("Components")]
    [SerializeField] private GameObject _ganeObject;
    [SerializeField] private Transform _transform;

    public Vector2Int[] Moves => _moves;
    public Vector2Int[] AttackMoves => _attackMoves;

    public Transform Transform => _transform;
    private void OnDrawGizmosSelected()
    {
        if (_moves == null || _attackMoves == null)
        {
            return;
        }

        foreach (Vector2 move in _moves)
        {
            Vector2 position = move * _transform.localScale * _spacing + (Vector2)_transform.localPosition;
            Gizmos.color = _moveColor;
            if (_attackMoves.Any(m => m == move))
            {
                Gizmos.color = _universalColor;
            }

            Gizmos.DrawWireCube(position, transform.localScale);

        }

        Gizmos.color = _attackColor;
        foreach (Vector2 attackMove in _attackMoves)
        {
            Vector2 position = attackMove * _transform.localScale * _spacing + (Vector2)_transform.localPosition;

            if (_moves.Any(m => m == attackMove))
            {
                continue;
            }
            Gizmos.DrawWireCube(position, transform.localScale);

        }
    }


    public void FindCell()
    {
        Collider2D[] coliders = Physics2D.OverlapBoxAll(_transform.position, _transform.localScale, 0);
        if (!coliders.Any())
        {
            return;
        }
        Cell cell = null;
        coliders.First(c => { cell = c.GetComponent<Cell>(); return cell != null; });
        if (cell != null)
        {
            cell.SetUnit(this);
            _cell = cell;
        }
    }

    public void Initialize(Cell cell)
    {
        cell.SetUnit(this);
        _cell = cell;
    }
}
