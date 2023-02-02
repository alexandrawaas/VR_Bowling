using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public int currentRound { get; private set; } = 1;
    public int currentPlayer { get; private set; } = 0;
    private Player[] players;

    // Start is called before the first frame update
    public GameState(int playersNumber)
    {
        players = new Player[playersNumber];
        for(int i = 0; i < playersNumber; i++)
        {
            players[i] = new Player("Player " + (i + 1));
        }
    }

    public bool StartNextPlayersTurn()
    {
        if (currentPlayer < players.Length-1)
        {
            currentPlayer++;
            return true;
        }
        return StartNextRound();
        // if this method returns false, the game is finished
    }

    public bool StartNextRound()
    {
        if (currentRound < 10)
        {
            currentRound++;
            currentPlayer = 0;
            return true;
        }
        
        // called when the last round has been played; GameController ends the game
        return false;
    }

    public Turn GetCurrentPlayersTurn()
    {
        return players[currentPlayer].GetCurrentTurn(currentRound-1);
    }
    
    public Player GetCurrentPlayerStats()
    {
        return players[currentPlayer];
    }
    
    public Player GetPlayer(int index)
    {
        try
        {
            return players[index];
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return players[0];
        }
    }

    public string GetWinner()
    {
        Player winner = null;
        var maxScore = 0;
        foreach (var player in players)
        {
            if (player.GetPlayerTotal() >= maxScore)
            {
                maxScore = player.GetPlayerTotal();
                winner = player;
            }
        }

        return winner == null? "Niemand" : winner.GetName();
    }

    public void SetScore(int score)
    {
        players[currentPlayer].SetScore(currentRound-1, score);
    }
}
