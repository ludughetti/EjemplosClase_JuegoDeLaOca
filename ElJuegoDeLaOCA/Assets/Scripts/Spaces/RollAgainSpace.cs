using UnityEngine;

public class RollAgainSpace : Space
{
    public RollAgainSpace()
    {
        spaceType = SpaceType.ROLL_AGAIN;
        textToShow = "Caiste sobre un casillero de Tira otra vez, clickea el dado nuevamente";
    }

    public override string ApplySpaceRule(Player player)
    {
        Debug.Log($"Player {player.GetPlayerName()} fell in a RollAgain space, set CanRollDiceAgain to true");
        player.SetCanRollDiceAgain(true);

        return textToShow;
    }
}