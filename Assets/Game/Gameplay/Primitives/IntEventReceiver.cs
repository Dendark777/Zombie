using System;
using UnityEngine;

namespace Assets.Game.Gameplay.Primitives
{
    public sealed class IntEventReceiver : MonoBehaviour
    {
        public event Action<int> OnEvent;

        public void Call(int value)
        {
            this.OnEvent?.Invoke(value);
        }
    }
}