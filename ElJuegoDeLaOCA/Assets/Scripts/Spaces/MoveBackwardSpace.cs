public class MoveBackwardSpace : Space
{
    public MoveBackwardSpace(int moveToPosition)
    {
        _spaceType = SpaceType.MOVE_BACKWARD;
        _moveToPosition = moveToPosition;
    }

    public override SpaceRuleResult ApplySpaceRule(ref Player player)
    {
        player.SetNextSpaceToMove(_moveToPosition);
        boardController.MovePlayer(player);

        return ReturnResultText();
    }
}