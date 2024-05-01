public class WinSpace : Space
{
    public WinSpace()
    {
        _spaceType = SpaceType.WIN;
    }

    public override SpaceRuleResult ApplySpaceRule(ref Player player)
    {
        return new SpaceRuleResult(textToShow, false, true);
    }
}