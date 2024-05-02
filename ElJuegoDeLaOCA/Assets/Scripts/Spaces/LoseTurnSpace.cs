using UnityEngine;

public class LoseTurnSpace : Space
{
    public LoseTurnSpace()
    {
        spaceType = SpaceType.LOSE_TURN;
        textToShow = "Pierdes un turno";
    }

    public override string ApplySpaceRule(Player player)
    {
        Debug.Log($"Player {player.GetPlayerName()} fell in a LoseTurn space, set CanPlayNextTurn to false");
        player.SetCanPlayNextTurn(false);
        return textToShow;
    }
}