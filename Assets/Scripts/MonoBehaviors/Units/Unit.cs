using Assets.Scripts.Editors;
using Assets.Scripts.MonoBehaviors.Cells;
using Assets.Scripts.SateMachines.Cells;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviors.Units
{

    public class Unit : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private List<Vector2Int> _moves;
        [SerializeField] private List<Vector2Int> _attackMoves;


        [SerializeField] private ItemDatabase _itemDatabase;
        [SerializeField] private Item _currentItem;
        private int currentIndex = 0;

        [SerializeField] private Cell _cell;

        [SerializeField] private float _spacing;

        [Header("Components")]
        [SerializeField] private GameObject _ganeObject;
        [SerializeField] private Transform _transform;

        [Header("Настройка движения")]
        [SerializeField] private int _actionCount;
        [SerializeField] private int _cellPerAction;

        public List<Vector2Int> Moves => _moves;
        public List<Vector2Int> AttackMoves => _attackMoves;
        private readonly int[] znak = new[] { 1, -1 };
        public Transform Transform => _transform;

        private void Awake()
        {
            _currentItem = _itemDatabase[currentIndex];
            CalculationAttack();
            CalculationMove();
        }

        private void CalculationMove()
        {
            Moves.Clear();
            for (int f = 0; f < 2; f++)
            {

                for (int i = 1; i <= _actionCount * _cellPerAction; i++)
                {
                    _moves.Add(new Vector2Int(i * znak[f], 0));
                    _moves.Add(new Vector2Int(0, i * znak[f]));
                }
            }
            for (int i = 1; i <= _actionCount; i++)
            {
                _moves.Add(new Vector2Int(i, i));
                _moves.Add(new Vector2Int(-1 * i, -1 * i));
                _moves.Add(new Vector2Int(-1 * i, i));
                _moves.Add(new Vector2Int(i, -1 * i));
            }
        }
        private void CalculationAttack()
        {
            AttackMoves.Clear();
            for (int f = 0; f < 2; f++)
            {

                for (int i = _currentItem.MinRadius; i <= _currentItem.MaxRadius; i++)
                {
                    _attackMoves.Add(new Vector2Int(i * znak[f], 0));
                    _attackMoves.Add(new Vector2Int(0, i * znak[f]));
                }
            }
            for (int i = 1; i <= _currentItem.MaxRadius/2; i++)
            {
                _attackMoves.Add(new Vector2Int(i, i));
                _attackMoves.Add(new Vector2Int(-1 * i, -1 * i));
                _attackMoves.Add(new Vector2Int(-1 * i, i));
                _attackMoves.Add(new Vector2Int(i, -1 * i));
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

        public void NextItem()
        {
            _currentItem = _itemDatabase.GetNext();
            CalculationAttack();
        }

        public void Initialize(Cell cell)
        {
            cell.SetUnit(this);
            _cell = cell;
        }
    }
}
