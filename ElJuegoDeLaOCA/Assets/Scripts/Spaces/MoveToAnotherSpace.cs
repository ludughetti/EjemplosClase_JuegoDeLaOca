public class MoveToAnotherSpace : Space
{
    public MoveToAnotherSpace()
    {
        spaceType = SpaceType.MOVE_TO_ANOTHER;
    }

    public override string ApplySpaceRule(Player player)
    {
        player.SetNextSpaceToMove(moveToPosition);
        boardController.MovePlayer(player, player.GetNextSpaceToMove());

        return textToShow + moveToPosition;
    }
}