using Assets.Scripts.MonoBehaviors.Cells;
using Assets.Scripts.MonoBehaviors.Units;
using Assets.Scripts.SateMachines.Cells;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameboardData : MonoBehaviour
{
    private Cell _selectedCell;
    private bool _haveSelectrdCell;

    public List<Cell> Cells { get; set; }
    public List<Unit> Units { get; set; }
    public static GameboardData Instance { get; private set; }

    private void Awake()
    {
        GetInstance();
    }

    public GameboardData GetInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        return Instance;
    }

    private void Start()
    {

        foreach (var cell in Cells)
        {
            //cell.StateChanged += TrySetSelected;
            //cell.StateChanged += TryRenderMoves;
            //cell.ClickAction += MoveUnit;
        }
    }

    private void OnDisable()
    {
        //foreach (var cell in _cells)
        //{
        //    cell.StateChanged -= TrySetSelected;
        //    //cell.StateChanged -= TryRenderMoves;
        //    //cell.ClickMoving -= MoveUnit;
        //}
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

    //private void TryRenderMoves(IState state, IState oldState, Cell cell)
    //{
    //    if (state is SelectState && oldState is DefaultState && cell.HaveUnit)
    //    {
    //        _movingCells = SetMovingCells(cell.Position, cell.Unit.Moves, cell.Unit.AttackMoves);
    //    }
    //}

    //private List<Cell> SetMovingCells(Vector2Int unitPosition, List<Vector2Int> moves, List<Vector2Int> attackMoves)
    //{
    //    List<Cell> cells = new List<Cell>();
    //    foreach (var move in moves)
    //    {
    //        Cell movingCell = FindCell(unitPosition, move, false);
    //        if (movingCell != null)
    //        {
    //            movingCell.SetMoving();
    //            cells.Add(movingCell);
    //        }
    //    }
    //    foreach (Vector2Int move in attackMoves)
    //    {
    //        Cell attackCell = FindCell(unitPosition, move, true);
    //        if (attackCell != null)
    //        {
    //            var movingCell = cells.FirstOrDefault(c => c == attackCell);
    //            if (movingCell != null)
    //            {
    //                movingCell.SetAttack();
    //            }
    //            else
    //            {
    //                attackCell.SetAttack();
    //                cells.Add(attackCell);
    //            }
    //        }
    //    }
    //    return cells;
    //}

    //public void MoveUnit(Cell cell)
    //{
    //    _unit.Initialize(cell);
    //    _selectedCell.Unselect();
    //}


    private Cell FindCell(Vector2Int unitPosition, Vector2Int move, bool haveUnit)
    {
        return Cells.FirstOrDefault(c => c.Position == move + unitPosition && c.HaveUnit == haveUnit);
    }

    public List<Cell> GetCells(Cell cell, int depth, int distance = 0)
    {
        List<Cell> cells = new();
        depth -= cell.Weight;
        cell.SetDistance(distance);
        foreach (Cell neighbour in cell.Neighbours)
        {
            if (neighbour.Distance != -1 && neighbour.Distance <= (cell.Distance + neighbour.Weight))
            {
                continue;
            }
            neighbour.SetDistance(distance + neighbour.Weight);
            cells.Add(neighbour);
            if (depth > 0)
            {
                cells.AddRange(GetCells(neighbour, depth, neighbour.Distance));

            }
        }
        return cells;
    }

    public void SetMovingCells(List<Cell> cells)
    {
        foreach (var move in cells)
        {
            move.SetMoving();
        }
    }

    private void ClearMoving(List<Cell> cells)
    {
        cells.ForEach(c => c.SetDefault());
    }

}
