using Assets.Scripts.MonoBehaviors.Units;
using Assets.Scripts.SateMachines.Cells;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Assets.Scripts.MonoBehaviors.Cells
{
    [Serializable]
    public class Cell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Data")]
        [SerializeField] private Vector2Int _position;
        [SerializeField] private Unit _unit;
        [SerializeField] private bool _haveUnit;
        [SerializeField] private List<Cell> _neighbours;
        [SerializeField] private int _distance;
        [Header("Components")]
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _transform;

                private StateMachine _stateMachine;

        private DefaultState _defaultState;
        private SelectState _selectState;
        private MovingState _movingState;
        private AttackState _attackState;

        public event StateHandler StateChanged;
        public event PointerStateHandler PointerChanged;
        private bool _pointerEnter;

        public event PointerHandler PointerClick;

        public Action<Cell> ClickAction;

        public delegate void StateHandler(IState state, IState oldState, Cell sender);

        public delegate void PointerStateHandler(bool pointerEnter, Cell sender);
        public delegate void PointerHandler(PointerEventData eventData);

        public GameObject GameObject => _gameObject;
        public int Weight
        {
            get
            {

                return 1;
            }
        }
        public IState CurrentState => _stateMachine.CurrentState;
        public List<Cell> Neighbours => _neighbours;
        public DefaultState DefaultState => _defaultState;
        public SelectState SelectState => _selectState;
        public int Distance => _distance;
        public Unit Unit => _unit;
        public bool HaveUnit => _haveUnit;
        public bool PointerEnter => _pointerEnter;
        public Vector2Int Position => _position;

        private void Awake()
        {
            _stateMachine = new();
            _distance = -1;
            _stateMachine.OnStateChanged += (state, oldState) => StateChanged?.Invoke(state, oldState, this);

            _defaultState = new DefaultState(_stateMachine, this);
            _selectState = new SelectState(_stateMachine, this);
            _movingState = new MovingState(_stateMachine, this);
            _attackState = new AttackState(_stateMachine, this);
            _stateMachine.InitializeState(_defaultState);

        }

        #region Взаимодействие с клеткой
        public void Initialize(Vector2Int position)
        {
            _position = position;
            _gameObject.name = $"X: {position.x}, Y:{position.y}";
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            PointerClick?.Invoke(eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _pointerEnter = true;
            PointerChanged?.Invoke(_pointerEnter, this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _pointerEnter = false;
            PointerChanged?.Invoke(_pointerEnter, this);
        }

        public void Unselect()
        {
            if (CurrentState is SelectState)
            {
                _stateMachine.ChangeState(_defaultState);
            }
        }
        #endregion

        public void UnitEnterToCell(Unit unit = null)
        {
            if (unit == null)
            {
                _haveUnit = false;
                _unit = null;
                return;
            }
            unit.gameObject.transform.position = new Vector3(_transform.position.x, _transform.position.y, -1);
            _unit = unit;
            _haveUnit = true;
        }

        public void UnitExitFromCell()
        {
            _unit = null;
        }

        internal void SetMoving()
        {
            _stateMachine.ChangeState(_movingState);
        }

        internal void SetAttack()
        {
            _stateMachine.ChangeState(_attackState);
        }

        public void SetDefault()
        {
            _distance = -1;
            _stateMachine.ChangeState(DefaultState);
        }

        public void SetNeighbours(List<Cell> neighbours)
        {
            _neighbours = neighbours;
        }
        public void SetDistance(int distance = -1)
        {
            _distance = distance;
        }
    }
}