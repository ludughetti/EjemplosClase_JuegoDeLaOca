using System.Collections.Generic;
using UnityEngine;

/* 
 * If the Dictionary is not configured in the UI, use this default board.
 */
public class DefaultBoard : MonoBehaviour
{
    private Dictionary<int, Space> _defaultBoard = new();
    private const int _totalSpacesInBoard = 36;

    private void Start()
    {
        for (int i = 1; i < _totalSpacesInBoard + 1; i++)
        {
            if(i == 2 || i == 7 || i == 14 || i == 2)
            {
                _defaultBoard[i] = new MoveForwardSpace(GetMoveForwardSpaceNextPosition(i));
            } else if(i == 5 || i == 18)
            {
                _defaultBoard[i] = new LoseTurnSpace();
            } else if(i == 12 || i == 25 || i == 30 || i == 33)
            {
                _defaultBoard[i] = new MoveBackwardSpace(GetMoveBackwardSpaceNextPosition(i));
            } else if(i == 31)
            {
                _defaultBoard[i] = new RollAgainSpace();
            } else if(i == 36)
            {
                _defaultBoard[i] = new WinSpace();
            } else
            {
                _defaultBoard[i] = new NormalSpace();
            }
        }
    }

    public Dictionary<int, Space> GetDefaultBoard()
    {
        return _defaultBoard;
    }

    private int GetMoveForwardSpaceNextPosition(int i)
    {
        return i switch
        {
            2 => 21,
            7 => 11,
            14 => 29,
            22 => 24,
            _ => 0,
        };
    }

    private int GetMoveBackwardSpaceNextPosition(int i)
    {
        return i switch
        {
            12 => 1,
            25 => 9,
            30 => 27,
            33 => 20,
            _ => 0,
        };
    }
}
