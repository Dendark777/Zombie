using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Gameplay.Primitives
{

    public class Vector3EventReceiver : MonoBehaviour
    {
        public event Action<Vector3> OnEvent;

        public void Call(Vector3 vector)
        {
            this.OnEvent?.Invoke(vector);
        }
    }
}
