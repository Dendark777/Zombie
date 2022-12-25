using Assets.Game.Gameplay.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Gameplay.Components
{
    public class MoveComponent : MonoBehaviour, IMoveComponent
    {
        [SerializeField]
        private Vector3EventReceiver moveReceiver;

        public void Move(Vector3 target)
        {
            throw new NotImplementedException();
        }
    }
}
