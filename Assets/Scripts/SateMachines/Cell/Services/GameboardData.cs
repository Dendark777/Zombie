using System;
using System.Collections;
using UnityEngine;

public class GameboardData : MonoBehaviour
{
    private Cell[] _cells;
    private Cell _selectedCell;
    private bool _haveSelectrdCell;

    private void Awake()
    {
        Cell[] cells = FindObjectsOfType<Cell>();

        if (cells.Length == 0) throw new NullReferenceException("Ячейки не найдены");
        _cells = cells;
        foreach (var cell in _cells)
        {
            cell.StateChanged += TrySetSelected;
        }
    }

    private void OnDisable()
    {
        foreach (var cell in _cells)
        {
            cell.StateChanged -= TrySetSelected;
        }
    }

    private void TrySetSelected(IState state, IState oldState, Cell cell)
    {
        if (state is SelectState && oldState is DefaultState)
        {
            if (_haveSelectrdCell)
            {
                _selectedCell.Unselect();
            }
            _selectedCell = cell;
            _haveSelectrdCell = true;
        }
        if (state is DefaultState && oldState is SelectState)
        {
            _selectedCell?.Unselect();
            _selectedCell = null;
            _haveSelectrdCell = false;
        }
    }
}
