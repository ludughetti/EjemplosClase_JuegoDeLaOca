using UnityEngine;

public class MoveToAnotherSpace : Space
{
    public MoveToAnotherSpace()
    {
        spaceType = SpaceType.MOVE_TO_ANOTHER;
    }

    public override string ApplySpaceRule(Player player)
    {
        Debug.Log($"Player {player.GetPlayerName()} fell in a MoveToAnother space, will move to position {moveToPosition}");
        player.SetNextSpaceToMove(moveToPosition);
        boardController.MovePlayer(player, player.GetNextSpaceToMove());

        return textToShow + moveToPosition;
    }
}