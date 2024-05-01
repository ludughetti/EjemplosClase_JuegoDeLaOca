public class NormalSpace : Space
{
    public NormalSpace()
    {
        spaceType = SpaceType.NORMAL;
        textToShow = "No paso nada";
    }

    public override string ApplySpaceRule(Player player)
    {
        player.ResetStatus();

        return textToShow;
    }
}