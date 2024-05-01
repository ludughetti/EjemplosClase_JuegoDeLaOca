using UnityEngine;

public class WinSpace : Space
{
    [SerializeField] GameController gameController;

    public WinSpace()
    {
        spaceType = SpaceType.WIN;
        textToShow = "Ganaste la partida!";
    }

    public override string ApplySpaceRule(Player player)
    {
        gameController.TriggerWin();
        return player.GetPlayerName() + textToShow;
    }
}