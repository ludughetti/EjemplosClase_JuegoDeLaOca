public class RollAgainSpace : Space
{
    public RollAgainSpace()
    {
        _spaceType = SpaceType.ROLL_AGAIN;
    }

    public override SpaceRuleResult ApplySpaceRule(ref Player player)
    {
        return new SpaceRuleResult(textToShow, true);
    }
}