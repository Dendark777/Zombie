using Assets.Scripts.MonoBehaviors.Cells;
using Assets.Scripts.MonoBehaviors.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Assets.Scripts.MonoBehaviors.Players
{
    [Serializable]
    public class PlayerSrc
    {
        private List<Unit> _units;
        private Unit _currentUnit;
        private Color _playerColor;
        public int CountUnits => _units.Count;
        public List<Unit> Units => _units;
        public Unit CurrentUnit => _currentUnit;
        public PlayerSrc(Color color)
        {
            _playerColor = color;
            _units = new List<Unit>();
        }

        public void SetCurrenetUnit(Unit unit)
        {
            _currentUnit?.ClearCells();
            _currentUnit = unit;
        }

        public void AddUnit(Unit unit)
        {
            _units.Add(unit);
            unit.SetOwner(this);
        }

        public void UnitMove(List<Cell> path)
        {
            _currentUnit.MoveTo(path);
        }


    }
}
