using Assets.Scripts.Editors;
using Assets.Scripts.MonoBehaviors.Cells;
using Assets.Scripts.MonoBehaviors.Players;
using Assets.Scripts.SateMachines.Cells;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using static Assets.Scripts.MonoBehaviors.Cells.Cell;
using static UnityEngine.UI.CanvasScaler;

namespace Assets.Scripts.MonoBehaviors.Units
{

    public class Unit : MonoBehaviour, IPointerClickHandler/*, IPointerEnterHandler, IPointerExitHandler*/
    {
        [SerializeField] private ItemDatabase _itemDatabase;
        [SerializeField] private Item _currentItem;

        [SerializeField] private Cell _cell;
        [SerializeField] private float _spacing;

        [Header("Настройка движения")]
        [SerializeField] private int _actionCount;
        [SerializeField] private int _cellPerAction;
        [SerializeField] private PlayerSrc _owner;


        [SerializeField] private List<Cell> _moves;
        [SerializeField] private List<Cell> _attackMoves;

        private GameboardData _gameboardData;
        public List<Cell> AttackMoves => _attackMoves;
        public List<Cell> Moves => _moves;
        public int CountCellsMove => _actionCount * _cellPerAction;
        public event PointerClickUnitHandler PointerClickUnit;
        public delegate void PointerClickUnitHandler(PointerEventData eventData);

        private void Awake()
        {
            _currentItem = _itemDatabase.GetNext();
            _moves = new List<Cell>();
            _attackMoves = new List<Cell>();
        }

        private void Start()
        {
            _gameboardData = GameboardData.Instance;
        }

        public void SetOwner(PlayerSrc player)
        {
            _owner = player;
            PointerClickUnit += ChoiceCell;
        }

        public void FindCell()
        {
            Collider2D[] coliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0);
            if (!coliders.Any())
            {
                return;
            }
            Cell cell = null;
            coliders.First(c => { cell = c.GetComponent<Cell>(); return cell != null; });
            if (cell != null)
            {
                cell.UnitEnterToCell(this);
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
            EnterToCell(cell);
            PointerClickUnit -= ChoiceCell;
            PointerClickUnit += ClickUnitOnBoard;
            GameManager.Instance.StartGame();
        }

        public void EndMove(Cell cell)
        {
            foreach (var cellM in _moves)
            {
                cellM.SetDefault();
            }
            EnterToCell(cell);
        }

        public void EnterToCell(Cell cell)
        {
            _cell?.UnitExitFromCell();
            _cell = cell;
            _cell.UnitEnterToCell(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            PointerClickUnit?.Invoke(eventData);
        }

        public void ChoiceCell(PointerEventData eventData)
        {
            print("Выбери клетку");
            _owner.SetCurrenetUnit(this);
            GameManager.Instance.SetStateChoiceCells();
        }

        public void ClickUnitOnBoard(PointerEventData eventData)
        {
            print("Клик по персонажу");
            _owner.SetCurrenetUnit(this);
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
            _moves.Clear();
            var cells = _gameboardData.GetCells(_cell, _actionCount * _cellPerAction).Distinct();
            foreach (var cell in cells)
            {
                _moves.Add(cell);
            }
            _moves.Add(_cell);
        }
        private void CalculationAttack()
        {
            AttackMoves.Clear();
            var cells = _gameboardData.GetCells(_cell, _currentItem.MaxRadius);
            foreach (var item in cells.Distinct())
            {
                AttackMoves.Add(item);
            }
        }

        public void ClearCells()
        {
            foreach (var cell in Moves)
            {
                cell.SetDefault();
            }
            foreach (var cell in AttackMoves)
            {
                cell.SetDefault();
            }
        }

        public void MoveTo(List<Cell> path)
        {
            StartCoroutine(MoveCoroutine(path));
        }

        private IEnumerator MoveCoroutine(List<Cell> path)
        {
            foreach (var target in path.Select(c => c.transform.position))
            {
                while (Vector3.zero != (target - transform.position))
                {
                    transform.position = Vector3.MoveTowards(transform.position, target, 20 * Time.deltaTime);
                    //transform.rotation = Quaternion.LookRotation(target - transform.position);
                    yield return new WaitForSeconds(0.01f);
                    print($"{target - transform.position}");
                }
            }

            EndMove(path.Last());

        }


        //public void OnPointerEnter(PointerEventData eventData)
        //{
        //    _cell.OnPointerEnter(eventData);
        //}

        //public void OnPointerExit(PointerEventData eventData)
        //{
        //    _cell.OnPointerEnter(eventData);
        //}


        //public void MoveUnit(Cell cell)
        //{
        //    _unit.Initialize(cell);
        //    _selectedCell.Unselect();
        //}
    }
}
