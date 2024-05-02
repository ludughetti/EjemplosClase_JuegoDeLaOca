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
        Debug.Log($"Player {player.GetPlayerName()} fell in a Win space, trigger GameController.TriggerWin()");
        gameController.TriggerWin();
        return textToShow;
    }
}