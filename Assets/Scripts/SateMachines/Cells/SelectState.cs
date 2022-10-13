using Assets.Scripts.MonoBehaviors.Cells;
using Assets.Scripts.SateMachines.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

public class SelectState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly Cell _cell;
    public SelectState(StateMachine stateMachine, Cell cell)
    {
        _stateMachine = stateMachine;
        _cell = cell;
    }

    public void Enter()
    {
        _cell.PointerClick += Unselect;
    }

    public void Exit()
    {
        _cell.PointerClick -= Unselect;
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }

    private void Unselect(PointerEventData eventData)
    {
        _stateMachine.ChangeState(_cell.DefaultState);
    }
}
