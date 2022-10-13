using Assets.Scripts.SateMachines.Cells;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviors.Cells
{
    public class CellView : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private Color _defaultColor = Color.white;
        [SerializeField] private Color _enterColor = new Color32(0x00,0xFF,0x00, 0xFF);
        [SerializeField] private Color _selectColor = new Color32(0x00, 0xC8, 0x00, 0xFF);
        [SerializeField] private Color _selectEnterColor = new Color32(0x00, 0x65, 0x00, 0xFF);
        [SerializeField] private Color _movingColor = new Color32(0x00, 0x00, 0xFF, 0xFF);
        [SerializeField] private Color _movingEnterColor = new Color32(0x00, 0x00, 0xC8, 0xFF);
        [SerializeField] private Color _attackColor = new Color32(0xFF, 0x00, 0x00, 0xFF);
        [SerializeField] private Color _attackEnterColor = new Color32(0xC8, 0x00, 0x00, 0xFF);

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

        private void SetColorState(IState cellState, bool pointerEnter)
        {
            _spriteRenderer.color = (cellState, pointerEnter) switch
            {
                (DefaultState, true) => _enterColor,
                (DefaultState, false) => _defaultColor,
                (SelectState, true) => _selectEnterColor,
                (SelectState, false) => _selectColor,
                (MovingState, true) => _movingEnterColor,
                (MovingState, false) => _movingColor,
                (AttackState, true) => _attackEnterColor,
                (AttackState, false) => _attackColor,
                _ => _spriteRenderer.color,
            };
        }
    }
}