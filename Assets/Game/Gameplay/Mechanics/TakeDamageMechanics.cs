using Assets.Game.Gameplay.Primitives;
using UnityEngine;

namespace Assets.Game.Gameplay.Mechanics
{
    public sealed class TakeDamageMechanics : MonoBehaviour
    {
        [SerializeField]
        private IntEventReceiver takeDamageReceiver;

        [SerializeField]
        private IntBehaviour hitPoints;

        private void OnEnable()
        {
            this.takeDamageReceiver.OnEvent += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            this.takeDamageReceiver.OnEvent -= this.OnDamageTaken;
        }

        private void OnDamageTaken(int damage)
        {
            this.hitPoints.Value -= damage;
        }
    }
}