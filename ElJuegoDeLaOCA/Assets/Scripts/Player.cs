using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private readonly string playerName;
    private bool _canPlayNextTurn = true;
    private int _currentSpace = 0;
    private int _nextSpaceToMove = 0;

    public string GetPlayerName()
    {
        return playerName;
    }

    public bool CanPlayNextTurn()
    {
        return _canPlayNextTurn;
    }

    public void SetCanPlayNextTurn(bool canPlayNextTurn)
    {
        _canPlayNextTurn = canPlayNextTurn;
    }

    public int GetCurrentSpace()
    {
        return _currentSpace;
    }

    public void SetCurrentSpace(int currentSpace)
    {
        _currentSpace = currentSpace;
    }

    public int GetNextSpaceToMove()
    {
        return _nextSpaceToMove;
    }

    public void SetNextSpaceToMove(int nextSpaceToMove)
    {
        _nextSpaceToMove = nextSpaceToMove;
    }

    public void ResetStatus()
    {
        _canPlayNextTurn = true;
        _nextSpaceToMove = 0;
    }

    public void UpdateCurrentSpace()
    {
        _currentSpace = _nextSpaceToMove;
    }
}