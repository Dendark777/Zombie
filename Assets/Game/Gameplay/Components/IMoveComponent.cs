using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Gameplay.Components
{
    public interface IMoveComponent
    {
        void Move(Vector3 target);
    }
}
