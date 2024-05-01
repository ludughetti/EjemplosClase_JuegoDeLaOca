using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private Dictionary<int, Space> board;

    public void InitializeBoard()
    {
        if (board == null || board.Count == 0)
        {
            DefaultBoard defaultBoard = new();
            board = defaultBoard.GetDefaultBoard();
        }
    }

    public Space MovePlayer(Player player)
    {
        if(board.TryGetValue(player.GetNextSpaceToMove() - 1, out Space space))
        {
            player.transform.SetParent(space.transform);
            player.transform.localPosition = Vector2.zero;
            player.UpdateCurrentSpace();
        }

        return space;
    }

    public int GetBoardSize()
    {
        return board.Count;
    }
}

