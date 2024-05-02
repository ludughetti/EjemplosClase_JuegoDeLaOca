using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Board")]
    [SerializeField] private BoardController boardController;
    [Header("Players")]
    [SerializeField] private List<Player> players = new();
    [Header("Dice")]
    [SerializeField] private int diceMaxValue = 6;
    [Header("Labels")]
    [SerializeField] private TMP_Text labelCurrentPlayer;
    [SerializeField] private TMP_Text labelWhatHappened;
    [SerializeField] private TMP_Text labelDiceResult;

    private const string ROLL_DICE = "Es tu turno, haz click sobre el dado!";
    private const string WAIT_FOR_NEXT_TURN = "Perdiste un turno, espera al siguiente!";

    private int _diceResult = 0;
    private bool _waitingForDice = false;
    private bool _playerHasWon = false;

    private void Start()
    {
        DoInitialSetup();

        StartCoroutine(PlayGame());
    }

    private void DoInitialSetup()
    {
        labelCurrentPlayer.text = "";
        labelWhatHappened.text = "";
        labelDiceResult.text = "?";

        Random.InitState((int) System.DateTime.Now.Ticks);

        boardController.InitializeBoard();
    }

    private IEnumerator PlayGame()
    {
        while(!_playerHasWon)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (_playerHasWon)
                    break;

                Player player = players[i];
                labelCurrentPlayer.text = player.GetPlayerName();

                if (!player.CanPlayNextTurn())
                {
                    SkipTurn(player);
                    yield return new WaitForSeconds(2);
                    continue;
                }

                labelWhatHappened.text = ROLL_DICE;

                // Wait for player to click the dice button
                Debug.Log("Wait for dice");
                while (_diceResult == 0)
                    yield return new WaitForEndOfFrame();

                Debug.Log($"Dice event registered, value is {_diceResult}");
                _waitingForDice = true;

                // Once the dice's been clicked, move the player and apply the rule for that space
                CalculateNextPosition(player);
                Space playerCurrentSpace = boardController.MovePlayer(player, player.GetNextSpaceToMove());
                yield return new WaitForSeconds(1);
                labelWhatHappened.text = playerCurrentSpace.ApplySpaceRule(player);
                yield return new WaitForSeconds(2);

                ResetDice();

                if (player.CanRollDiceAgain())
                    i--;
            }
        }

        Debug.Log("Game over, a player won.");
    }

    public void TriggerOnDiceRoll()
    {
        if(_diceResult == 0)
            StartCoroutine(RollDice());
    }

    public IEnumerator RollDice()
    {
        if (!_waitingForDice)
            yield return new WaitForEndOfFrame();

        int resultado = Random.Range(1, diceMaxValue + 1);
        labelDiceResult.text = resultado.ToString();

        _diceResult = resultado;
    }

    private void CalculateNextPosition(Player player)
    {
        int nextSpaceToMove = Mathf.Min(boardController.GetBoardSize(), player.GetCurrentSpace() + _diceResult);
        player.SetNextSpaceToMove(nextSpaceToMove);
    }

    private void SkipTurn(Player player)
    {
        player.SetCanPlayNextTurn(true);
        labelWhatHappened.text = WAIT_FOR_NEXT_TURN;
    }

    private void ResetDice()
    {
        _waitingForDice = false;
        _diceResult = 0;
    }

    public void TriggerWin()
    {
        _playerHasWon = true;
    }
}
