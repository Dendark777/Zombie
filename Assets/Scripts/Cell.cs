using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public event StateHandler StateChanged;
    public event PointerStateHandler PointerChanged;

    public event PointerHandler PointerClick;

    public delegate void StateHandler(IState state, IState oldState, Cell sender);

    public delegate void PointerStateHandler(bool pointerEnter, Cell sender);
    public delegate void PointerHandler(PointerEventData eventData);
    [Header("Data")]
    [SerializeField] private Vector2Int _position;

    [Header("Components")]
    [SerializeField] private GameObject _gameObject;

    private StateMachine _stateMachine;
    private DefaultState _defaultState;
    private SelectState _selectState;
    public GameObject GameObject => _gameObject;
    public IState CurrentState => _stateMachine.CurrentState;

    public DefaultState DefaultState => _defaultState;
    public SelectState SelectState => _selectState;

    public bool _pointerEnter;

    public bool PointerEnter => _pointerEnter;
    private void Awake()
    {
        _stateMachine = new();

        _stateMachine.OnStateChanged +=(state,oldState) => StateChanged?.Invoke(state,oldState,this);

        _defaultState = new DefaultState(_stateMachine, this);
        _selectState = new SelectState(_stateMachine, this);
        _stateMachine.InitializeState(_defaultState);

    }

    private void OnValidate()
    {
        if (_gameObject == null)
        {
            _gameObject = gameObject;
        }
    }

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
}