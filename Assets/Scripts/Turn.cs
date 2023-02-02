using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn
{
    // Start is called before the first frame update
    public int[] throws { get; private set; } = {0,0,0};
    public int currentThrow { get; private set; } = 0;
    public bool isStrike { get; private set; } = false;
    public bool isSpare { get; private set; } = false;
    public int total { get; private set; } = 0;

    public bool SetScore(int score)
    {
        if (currentThrow < 2)
        {
            throws[currentThrow] = score;
            
            if (score == 10)
            {
                isStrike = true;
                Debug.Log("Strike! Strike in Turn is "+isStrike);
            }
            else if (currentThrow == 1 && score + throws[0] == 10)
            {
                Debug.Log("Spare!");
                isSpare = true;
            }
            
            total += score;
            
            return true;
        }
        // TODO Letzte Runde und Strike handeln
        return false;
    }

    public void IncreaseThrowNumber()
    {
        currentThrow++;
    }

    public int GetScoreBefore()
    {
        return currentThrow > 0 ? throws[currentThrow - 1] : 0;
    }

    public void AddToTotal(int score)
    {
        total += score;
    }
}