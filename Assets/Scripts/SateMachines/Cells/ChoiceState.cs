using Assets.Scripts.MonoBehaviors.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

namespace Assets.Scripts.SateMachines.Cells
{
    public class ChoiceState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly Cell _cell;
        public ChoiceState(StateMachine stateMachine, Cell cell)
        {
            _stateMachine = stateMachine;
            _cell = cell;
        }

        public void Enter()
        {
            _cell.PointerClick += ChoiceCell;
        }

        public void Exit()
        {
            _cell.PointerClick -= ChoiceCell;
        }

        private void ChoiceCell(PointerEventData eventData)
        {
            _cell.ClickAction?.Invoke(_cell);
        }

    }
}
