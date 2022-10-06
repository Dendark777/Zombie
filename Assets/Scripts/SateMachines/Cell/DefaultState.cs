﻿using Mono.Cecil.Cil;
using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class DefaultState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly Cell _cell;
    public DefaultState(StateMachine stateMachine, Cell cell)
    {
        _stateMachine = stateMachine;
        _cell = cell;
    }

    public void Enter()
    {
        _cell.PointerClick += Select;
    }

    public void Exit()
    {
        _cell.PointerClick -= Select;
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
    private void Select(PointerEventData eventData)
    {
        _stateMachine.ChangeState(_cell.SelectState);
    }
}
