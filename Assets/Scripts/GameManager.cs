using Assets.Scripts.MonoBehaviors.Cells;
using Assets.Scripts.MonoBehaviors.Players;
using Assets.Scripts.MonoBehaviors.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Unit _unitPref;
    [SerializeField] private GameObject _storageUnits;
    [SerializeField] private GameObject _playersStorageUnits;

    private List<PlayerSrc> _players;
    private PlayerSrc _currentPlayer;

    public static GameManager Instance { get; private set; }
    public List<Cell> Cells { get; set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        _players = new List<PlayerSrc>
        {
            new PlayerSrc(Color.red)
        };
        _currentPlayer = _players[0];
        InstatiateUnitsInPlayersStorage();
        InstatiateUnitsInStorage();
    }

    private void InstatiateUnitsInStorage()
    {
        foreach (var unit in _currentPlayer.Units)
        {
            unit.transform.SetParent(_storageUnits.transform, false);
        }
    }
    private void InstatiateUnitsInPlayersStorage()
    {
        for (int i = 0; i < 3; i++)
        {
            var unit = Instantiate(_unitPref, _storageUnits.transform, false);
            _currentPlayer.AddUnit(unit);
        }
    }

    public void SetStateChoiceCells()
    {
        foreach (var cell in Cells)
        {
            cell.SetDefault();
            cell.PointerClick += TrySetSelected;
        }
    }

    public void StartGame()
    {
        foreach (var cell in Cells)
        {
            cell.SetDistance();
            cell.PointerClick -= TrySetSelected;
        }
    }

    public void MoveUnit(Cell target)
    {
        _currentPlayer.UnitMove(GetPath(target));
    }

    private List<Cell> GetPath(Cell target)
    {
        var path = new List<Cell>();
        path.Add(target);
        path.AddRange(CreatePath(target));
        path.Reverse();
        return path;
    }

    private List<Cell> CreatePath(Cell cell)
    {
        var result = new List<Cell>();
        var minDistance = cell.Neighbours.Where(c => c.Distance != -1).Min(c => c.Distance);
        var needCell = cell.Neighbours.FirstOrDefault(c => c.Distance == minDistance);
        if (minDistance != 0)
        {
            result.Add(needCell);
            result.AddRange(CreatePath(needCell));
        }
        return result;
    }

    private void TrySetSelected(PointerEventData eventData)
    {
        _currentPlayer.CurrentUnit.Initialize(eventData.pointerClick.GetComponent<Cell>());
    }
}
