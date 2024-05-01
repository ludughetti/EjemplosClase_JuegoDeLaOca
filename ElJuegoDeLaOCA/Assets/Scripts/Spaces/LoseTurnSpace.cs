public class LoseTurnSpace : Space
{
    public LoseTurnSpace()
    {
        spaceType = SpaceType.LOSE_TURN;
        textToShow = "Pierdes un turno";
    }

    public override string ApplySpaceRule(Player player)
    {
        player.SetCanPlayNextTurn(false);
        return textToShow;
    }
}