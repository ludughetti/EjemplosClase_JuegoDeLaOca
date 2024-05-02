using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [Header("Spaces")]
    [SerializeField] private List<Space> spacesList;

    private Dictionary<int, Space> _board = new();

    public void InitializeBoard()
    {
        if (spacesList == null || spacesList.Count == 0)
        {
            Debug.LogWarning($"{name}: Board doesn't contain any spaces to play");
        }

        for (int i = 0; i < spacesList.Count; i++)
        {
            Space space = spacesList[i];
            _board.Add(i, space);
            Debug.Log($"New entry added to board dictionary <{i},{space.GetType()}>. Total count is {_board.Count}");
        }
    }

    public Space MovePlayer(Player player, int nextSpaceToMove)
    {
        if (_board.TryGetValue(nextSpaceToMove - 1, out Space space))
        {
            player.GetComponent<Transform>().SetParent(space.GetComponent<Transform>());
            player.GetComponent<Transform>().localPosition = Vector2.zero;
            player.UpdateCurrentSpace();

            Debug.Log($"Moved player and updated its current position to {player.GetCurrentSpace()}");
        }

        return space;
    }

    public int GetBoardSize()
    {
        return _board.Count;
    }
}