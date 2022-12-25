using System;
using UnityEngine;

namespace Assets.Game.Gameplay.Primitives
{
    public sealed class EventReceiver : MonoBehaviour
    {
        public event Action OnEvent;

        public void Call()
        {
            Debug.Log($"Event {name} was received!");
            this.OnEvent?.Invoke();
        }
    }
}