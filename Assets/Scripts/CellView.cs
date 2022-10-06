using System.Collections;
using UnityEngine;

public class CellView : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private Color _defaultColor = Color.white;
    [SerializeField] private Color _enterColor = Color.white;
    [SerializeField] private Color _selectColor = Color.white;
    [SerializeField] private Color _selectEnterColor = Color.white;

    [Header("Components")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Cell _cell;

    private void OnEnable()
    {
        _cell.StateChanged += (state, oldState, sender) => SetColorState(state, sender.PointerEnter);
        _cell.PointerChanged += (pointerEnter, sender) => SetColorState(sender.CurrentState, pointerEnter);
    }

    private void OnDisable()
    {
        _cell.StateChanged -= (state, oldState, sender) => SetColorState(state, sender.PointerEnter);
        _cell.PointerChanged -= (pointerEnter, sender) => SetColorState(sender.CurrentState, pointerEnter);
    }

    private void OnValidate()
    {
        if (_spriteRenderer == null)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        if (_cell == null)
        {
            _cell = GetComponent<Cell>();
        }
    }

    private void SetColorState(IState cellState, bool pointerEnter)
    {
        _spriteRenderer.color = (cellState, pointerEnter) switch
        {
            (DefaultState, true) => _enterColor,
            (DefaultState, false) => _defaultColor,
            (SelectState, true) => _selectEnterColor,
            (SelectState, false) => _selectColor,
            //(Mov, true) => _selectEnterColor,
            //(SelectState, false) => _selectColor,
            _ => _spriteRenderer.color,
        };
    }
}