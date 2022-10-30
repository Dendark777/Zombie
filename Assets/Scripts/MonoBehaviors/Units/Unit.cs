using Assets.Scripts.Editors;
using Assets.Scripts.MonoBehaviors.Cells;
using Assets.Scripts.SateMachines.Cells;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.UI.CanvasScaler;

namespace Assets.Scripts.MonoBehaviors.Units
{

    public class Unit : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Data")]
        [SerializeField] private List<Cell> _moves;
        [SerializeField] private List<Vector2Int> _attackMoves;


        [SerializeField] private ItemDatabase _itemDatabase;
        [SerializeField] private Item _currentItem;

        [SerializeField] private Cell _cell;

        [SerializeField] private float _spacing;

        [Header("Components")]
        [SerializeField] private GameObject _ganeObject;
        [SerializeField] private Transform _transform;

        [Header("Настройка движения")]
        [SerializeField] private int _actionCount;
        [SerializeField] private int _cellPerAction;

        private GameboardData _gameboardData;

        public List<Cell> Moves => _moves;
        public int CountCellsMove => _actionCount * _cellPerAction;
        public List<Vector2Int> AttackMoves => _attackMoves;
        public Transform Transform => _transform;

        private void Awake()
        {
            _currentItem = _itemDatabase.GetNext();
        }

        private void Start()
        {
            _gameboardData = GameboardData.Instance;
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

        public void OnPointerClick(PointerEventData eventData)
        {
            print("Клик по персонажу");
            CalculationMove();
            CalculationAttack();
            _cell.OnPointerClick(eventData);
            foreach (var cell in _moves)
            {
                cell.SetMoving();
            }
        }

        private void CalculationMove()
        {
            Moves.Clear();
            var cells = _gameboardData.GetCells(_cell, _actionCount * _cellPerAction);
            foreach (var item in cells)
            {
                Moves.Add(item);
            }
        }
        private void CalculationAttack()
        {
            AttackMoves.Clear();
            var cells = _gameboardData.GetCells(_cell, _currentItem.MaxRadius);
            foreach (var item in cells.Distinct())
            {
                AttackMoves.Add(item.Position);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _cell.OnPointerEnter(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _cell.OnPointerEnter(eventData);
        }


        //public void MoveUnit(Cell cell)
        //{
        //    _unit.Initialize(cell);
        //    _selectedCell.Unselect();
        //}
    }
}
