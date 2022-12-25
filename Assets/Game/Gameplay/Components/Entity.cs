using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Gameplay.Components
{
    public class Entity : MonoBehaviour
    {
        [SerializeField]
        private List<MonoBehaviour> _components;

        public T Get<T>()
        {
            foreach (var component in _components)
            {
                if (component is T result)
                {
                    return result;
                }
            }
            throw new Exception($"Не найден компонент типа {typeof(T).Name}");
        }

        public bool TryGet<T>(out T result)
        {
            foreach (var component in _components)
            {
                if (component is T tComponent)
                {
                    result = tComponent;
                    return true;
                }
            }
            result = default;
            return false;
        }
    }
}
