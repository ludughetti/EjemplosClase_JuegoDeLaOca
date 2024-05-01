using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private BoardController boardController;
    [SerializeField] private List<Player> players = new();
    [SerializeField] private TMP_Text labelCurrentPlayer;
    [SerializeField] private TMP_Text labelWhatHappened;
    [SerializeField] private TMP_Text labelDiceResult;

    private int _totalSpacesInBoard = 0;
    private int _diceResult = 0;
    private bool _waitingForDice = false;
    private bool _playerHasWon = false;

    private void Start()
    {
        SetupInitialText();
        _playerHasWon = false;
        StartCoroutine(PlayGame());
    }

    private void SetupInitialText()
    {
        labelCurrentPlayer.text = "";
        labelWhatHappened.text = "";
        labelDiceResult.text = "?";
    }

    private IEnumerator PlayGame()
    {
        _totalSpacesInBoard = boardController.GetBoardSize();

        while (!_playerHasWon)
        {
            foreach (Player player in players)
            {
                labelCurrentPlayer.text = player.name;
                StartCoroutine(PlayTurn(player));
            }

            yield return null;
        }
    }

    private IEnumerator PlayTurn(Player player)
    {
        // Wait for player to click the dice button
        while (_diceResult == 0)
            yield return new WaitForEndOfFrame();

        _waitingForDice = true;

        // Once the dice's been clicked, move the player
        MovePlayerToSpace(player);
        Space playerCurrentSpace = boardController.MovePlayer(player);
        yield return new WaitForSeconds(1);

        // Apply the rule for that space
        SpaceRuleResult result = playerCurrentSpace.ApplySpaceRule(ref player);
        CheckSpaceRuleResult(result, player);
    }

    private IEnumerator OnRollDice()
    {
        if (!_waitingForDice)
            yield return new WaitForEndOfFrame();

        System.Random r = new();

        int resultado = r.Next(1, 7);
        labelDiceResult.text = resultado.ToString();

        _diceResult = resultado;
    }

    private void MovePlayerToSpace(Player player)
    {
        int nextSpaceToMove = Math.Min(_totalSpacesInBoard, player.GetCurrentSpace() + _diceResult);
        player.SetNextSpaceToMove(nextSpaceToMove);
    }

    private void CheckSpaceRuleResult(SpaceRuleResult result, Player player)
    {
        labelWhatHappened.text = result.GetTextToShow();

        if (result.IsWin())
        {
            _playerHasWon = true;
            return;
        }

        ResetDice();

        if (result.CanRollDiceAgain())
            StartCoroutine(PlayTurn(player));
            
    }

    private void ResetDice()
    {
        _waitingForDice = false;
        _diceResult = 0;
    }

    private IEnumerator Old_PlayTurn()  // ---> TAREA: Refactorear este método para que sea mas "clean code"
    {
        _diceResult = 0;
        labelWhatHappened.text = "";

        if (_turnCounter == 1)
        {
            labelCurrentPlayer.text = "1";
            if (!pierdeTurno1)
            {
                _waitingForDice = true;
                while (_diceResult == 0)
                {
                    yield return new WaitForEndOfFrame();
                }
                _waitingForDice = false;
                posicionJugador1 = Math.Min(36, posicionJugador1 + _diceResult);
                labelWhatHappened.text = "Sacó un " + _diceResult.ToString() + " y se mueve al casillero nro " + posicionJugador1.ToString();
                board.MovePlayer(_turnCounter, posicionJugador1);
                yield return new WaitForSeconds(1);

                //posicionJugador1 = CheckWhatHappens(1, posicionJugador1);
                board.MovePlayer(_turnCounter, posicionJugador1);
            }
            else
            {
                labelWhatHappened.text = "había perdido el turno - no juega";
                pierdeTurno1 = false;
            }

            done = posicionJugador1 == 36;
            _turnCounter = 2;
        }
        else //if (turno == 2)
        {
            labelCurrentPlayer.text = "2";
            if (!pierdeTurno2)
            {
                _waitingForDice = true;
                while (_diceResult == 0)
                {
                    yield return new WaitForEndOfFrame();
                }
                _waitingForDice = false;
                posicionJugador2 = Math.Min(36, posicionJugador2 + _diceResult);
                labelWhatHappened.text = "Sacó un " + _diceResult.ToString() + " y se mueve al casillero nro " + posicionJugador2.ToString();
                board.MovePlayer(_turnCounter, posicionJugador2);
                yield return new WaitForSeconds(1);

                //posicionJugador2 = CheckWhatHappens(2, posicionJugador2);
                board.MovePlayer(_turnCounter, posicionJugador2);
            }
            else
            {
                labelWhatHappened.text = "había perdido el turno - no juega";
                pierdeTurno2 = false;
            }

            done = posicionJugador2 == 36;
            _turnCounter = 1;
        }

        if (done)
        {
            if (posicionJugador1 == 36)
                labelWhatHappened.text = "Gana el jugador 1 - fin del juego";
            else
                labelWhatHappened.text = "Gana el jugador 2 - fin del juego";
        }
        else
        {
            yield return new WaitForSeconds(2);
            StartCoroutine(PlayTurn());
        }
    }
}
