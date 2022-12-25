using System;
using UnityEngine;

namespace Assets.Game.Gameplay.Primitives
{
    public sealed class FloatBehaviour : MonoBehaviour
    {
        public event Action<float> OnValueChanged;

        public float Value
        {
            get { return this._value; }
            set
            {
                this._value = value;
                this.OnValueChanged?.Invoke(value);
            }
        }

        [SerializeField]
        private float _value;
    }
}