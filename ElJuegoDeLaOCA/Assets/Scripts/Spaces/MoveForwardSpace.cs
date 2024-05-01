public class MoveForwardSpace : Space
{
    public MoveForwardSpace(int moveToPosition)
    {
        _spaceType = SpaceType.MOVE_FORWARD;
        _moveToPosition = moveToPosition;
    }

    public override SpaceRuleResult ApplySpaceRule(ref Player player)
    {
        player.SetNextSpaceToMove(_moveToPosition);
        boardController.MovePlayer(player);

        return ReturnResultText();
    }
}