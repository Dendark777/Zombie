using Assets.Scripts.SateMachines.Cell;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameboardData : MonoBehaviour
{
    private Cell[] _cells;
    private Cell _selectedCell;
    private bool _haveSelectrdCell;

    private List<Cell> _movingCells = new();
    private Unit _unit;


    private void Awake()
    {
        Cell[] cells = FindObjectsOfType<Cell>();

        if (cells.Length == 0)
        {
            throw new NullReferenceException("Ячейки не найдены");
        }
        _cells = cells;
        foreach (var cell in _cells)
        {
            cell.StateChanged += TrySetSelected;
            cell.StateChanged += TryRenderMoves;
            cell.ClickMoving += MoveUnit;
        }
    }

    private void OnDisable()
    {
        foreach (var cell in _cells)
        {
            cell.StateChanged -= TrySetSelected;
            cell.StateChanged -= TryRenderMoves;
            cell.ClickMoving -= MoveUnit;
        }
    }

    private void TrySetSelected(IState state, IState oldState, Cell cell)
    {
        if (state is SelectState && oldState is DefaultState)
        {
            if (_haveSelectrdCell)
            {
                _selectedCell.Unselect();
                ClearMoving();
            }
            _selectedCell = cell;
            _haveSelectrdCell = true;
        }
        if (state is DefaultState && oldState is SelectState)
        {
            _selectedCell?.Unselect();
            ClearMoving();
            _selectedCell = null;
            _haveSelectrdCell = false;
        }
    }

    private void TryRenderMoves(IState state, IState oldState, Cell cell)
    {
        if (state is SelectState && oldState is DefaultState && cell.HaveUnit)
        {
            _movingCells = SetMovingCells(cell.Position, cell.Unit.Moves, cell.Unit.AttackMoves);

            _unit = cell.Unit;
        }
    }

    private List<Cell> SetMovingCells(Vector2Int unitPosition, Vector2Int[] moves, Vector2Int[] attackMoves)
    {
        List<Cell> cells = new List<Cell>();
        foreach (var move in moves)
        {
            Cell movingCell = FindCell(unitPosition, move, false);
            if (movingCell != null)
            {
                movingCell.SetMoving();
                cells.Add(movingCell);
            }
        }
        foreach (Vector2Int move in attackMoves)
        {
            Cell attackCell = FindCell(unitPosition, move, true);
            if (attackCell != null)
            {
                var movingCell = cells.FirstOrDefault(c => c == attackCell);
                if (movingCell != null)
                {
                    movingCell.SetAttack();
                }
                else
                {
                    attackCell.SetAttack();
                    cells.Add(attackCell);
                }
            }
        }
        return cells;
    }

    private void ClearMoving()
    {
        _movingCells.ForEach(c => c.SetDefault());
        _movingCells.Clear();
    }

    public void MoveUnit(Cell cell)
    {
        _unit.Initialize(cell);
        _selectedCell.Unselect();
    }


    private Cell FindCell(Vector2Int unitPosition, Vector2Int move, bool haveUnit)
    {
        return _cells.FirstOrDefault(c => c.Position == move + unitPosition && c.HaveUnit == haveUnit);
    }
}
