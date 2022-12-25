using Assets.Game.Gameplay.Components;
using System;
using UnityEngine;

namespace Assets.Game.Gameplay.Primitives
{
    public sealed class EntityEventReceiver : MonoBehaviour
    {
        public event Action<Entity> OnEvent;

        public void Call(Entity entity)
        {
            this.OnEvent?.Invoke(entity);
        }
    }
}