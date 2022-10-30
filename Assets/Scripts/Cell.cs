using UnityEngine;

namespace Scripts.BoardLogic
{
    public class Cell : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private Vector2Int _position;

        [Header("Components")]
        [SerializeField] private GameObject _gameObject;

        public GameObject GameObject => _gameObject;


        internal void Initialize(Vector2Int position, int number)
        {
            
            _position = position;

            _gameObject.name = $"Tail X: {position.x}, Y: {position.y} nom {number}";
           
        }
    }
}