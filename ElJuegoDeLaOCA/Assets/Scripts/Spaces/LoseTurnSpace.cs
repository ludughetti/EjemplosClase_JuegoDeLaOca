public class LoseTurnSpace : Space
{
    public LoseTurnSpace()
    {
        _spaceType = SpaceType.LOSE_TURN;
    }

    public override SpaceRuleResult ApplySpaceRule(ref Player player)
    {
        player.SetCanPlayNextTurn(false);
        return ReturnResultText();
    }
}