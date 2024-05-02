using UnityEngine;

public class NormalSpace : Space
{
    public NormalSpace()
    {
        spaceType = SpaceType.NORMAL;
        textToShow = "No paso nada";
    }

    public override string ApplySpaceRule(Player player)
    {
        Debug.Log($"Player {player.GetPlayerName()} fell in a Normal space, reset status");
        player.ResetStatus();

        return textToShow;
    }
}