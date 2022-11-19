using Assets.Scripts.MonoBehaviors.Cells;
using Assets.Scripts.MonoBehaviors.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

namespace Assets.Scripts.SateMachines.Units
{
    public class ChoiceCellState : StateMachine
    {
        private readonly StateMachine _stateMachine;
        private readonly Unit _unit;
        public ChoiceCellState(StateMachine stateMachine, Unit unit)
        {
            _stateMachine = stateMachine;
            _unit = unit;
        }

        public void Enter()
        {
            _unit.PointerClickUnit += Attack;
        }

        public void Exit()
        {
            _unit.PointerClickUnit -= Attack;
        }

        private void Attack(PointerEventData eventData)
        {
            //_unit.ChoiceCell?.Invoke(_unit);
        }
    }
}
