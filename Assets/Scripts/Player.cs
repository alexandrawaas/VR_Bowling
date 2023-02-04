using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string playerName;

    public Turn[] turns { get; private set; }
    // Start is called before the first frame update
    public Player(string name)
    {
        playerName = name;
        turns = new Turn[10];
        for(int i = 0; i < 10; i++)
        {
            turns[i] = new Turn();
        }
    }

    public void SetScore(int turnIndex, int score)
    {
        turns[turnIndex].SetScore(turnIndex, score);
        
        // Handle Strike and Spare Bonus Points
        if(turnIndex < 9)
        {
            if (turnIndex > 0 && turns[turnIndex - 1].isStrike)
            {
                turns[turnIndex - 1].AddToTotal(score);
            }

            if (turns[turnIndex - 1].isSpare && turns[turnIndex].currentThrow == 0)
            {
                turns[turnIndex - 1].AddToTotal(score);
            }

            // Handle special case where a Strike follows another Strike
            if (turnIndex > 1 && turns[turnIndex - 2].isStrike && turns[turnIndex - 1].isStrike)
            {
                turns[turnIndex - 2].AddToTotal(score);
            }
        }
        else
        {
            if (turns[turnIndex - 1].isStrike && turns[turnIndex].currentThrow < 2)
            {
                turns[turnIndex - 1].AddToTotal(score);
            }

            if (turns[turnIndex - 1].isSpare && turns[turnIndex].currentThrow == 0)
            {
                turns[turnIndex - 1].AddToTotal(score);
            }
        }
    }

    public int GetPlayerTotal()
    {
        int result = 0;
        foreach (var turn in turns)
        {
            result += turn.total;
        }
        return result;
    }

    public Turn GetCurrentTurn(int turnIndex)
    {
        return turns[turnIndex];
    }

    public string GetName()
    {
        return playerName;
    }
}
