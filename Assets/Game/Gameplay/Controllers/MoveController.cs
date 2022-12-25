using Assets.Game.Gameplay.Components;
using Assets.Scripts.MonoBehaviors.Cells;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    private Entity _currentEntity;
    IMoveComponent _moveComponent;

    private void Awake()
    {
        _moveComponent = _currentEntity.Get<IMoveComponent>();
    }

    public void SetCurrnetEntity(IMoveComponent component)
    {
        _moveComponent = component;

    }

    public void Move(List<Cell> path)
    {

    }
}
