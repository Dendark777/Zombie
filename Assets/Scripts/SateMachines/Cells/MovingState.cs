using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using Assets.Scripts.MonoBehaviors.Cells;

namespace Assets.Scripts.SateMachines.Cells
{
    public class MovingState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly Cell _cell;
        public MovingState(StateMachine stateMachine, Cell cell)
        {
            _stateMachine = stateMachine;
            _cell = cell;
        }

        public void Enter()
        {
            _cell.PointerClick += Moving;
        }

        public void Exit()
        {
            _cell.PointerClick -= Moving;
        }

        public void Update()
        {
        }

        private void Moving(PointerEventData eventData)
        {
            _cell.ClickMoving?.Invoke(_cell);
        }
    }
}
