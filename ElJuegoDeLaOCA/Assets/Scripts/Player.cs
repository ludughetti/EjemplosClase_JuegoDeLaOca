using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string playerName;
    private bool _canRollDiceAgain = false;
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

    public bool CanRollDiceAgain()
    {
        return _canRollDiceAgain;
    }

    public void SetCanRollDiceAgain(bool canRollDiceAgain)
    {
        _canRollDiceAgain = canRollDiceAgain;
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
        _canRollDiceAgain = false;
        _nextSpaceToMove = _currentSpace;
    }

    public void UpdateCurrentSpace()
    {
        _currentSpace = _nextSpaceToMove;
    }
}