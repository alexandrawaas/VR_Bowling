using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGui : MonoBehaviour
{
    [SerializeField] private TMP_Text[] throwScoreFields;
    [SerializeField] private TMP_Text[] roundTotalFields;
    [SerializeField] private TMP_Text totalField;
    [SerializeField] private TMP_Text playerName;

    private readonly Color currentPlayerColor = new (0.6f, 0.4f, 1f, 1f);
    private readonly Color otherPlayersColor = new (0.7f, 0.7f, 0.8f, 0.3f);
    private int throwNumber;
    private int currentTurnIndex;

    public void SetScore(int turnIndex, Turn currentTurn, int? fallenPins)
    {
        throwNumber = currentTurn.currentThrow;
        currentTurnIndex = turnIndex;
        int scoreBefore = currentTurn.GetScoreBefore();
        int score;
        try
        {
            score = (int)fallenPins;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            score = 0;
        }

        if (turnIndex < 0 || turnIndex > 10 || throwNumber < 0 || (throwNumber > 2 && turnIndex < 10) || (throwNumber > 3 && turnIndex == 10))
        {
            throw new ArgumentException("Parameter out of range");
        }

        if (turnIndex == 10 && throwNumber == 3)
        {
            throwScoreFields[^1].text = IntToScoreFieldText(score, scoreBefore);
        }
        
        if (throwNumber == 0) 
        {
            throwScoreFields[turnIndex*2].text=IntToScoreFieldText(score, scoreBefore);
        }
        else if (throwNumber == 1)
        {
            throwScoreFields[turnIndex*2+1].text=IntToScoreFieldText(score, scoreBefore);
        }
        else if (throwNumber == 2)
        {
            throwScoreFields[turnIndex*2+2].text=IntToScoreFieldText(score, scoreBefore);
        }
    }

    public void UpdateAllFields(GameState gameState, int index)
    {
        Player stats = gameState.GetPlayer(index);
        UpdateRoundFieldsUntilCurrent(stats);
        UpdateTotalField(stats);
    }
    
    private void UpdateRoundFieldsUntilCurrent(Player playerStats)
    {
        for (var i = 0; i <= currentTurnIndex; i++)
        {
            var result = 0;
            for(int j = 0; j<=i; j++)
            {
                result += playerStats.turns[j].total;

            }
            roundTotalFields[i].text = result.ToString();
        }
    }

    private void UpdateTotalField(Player playerStats)
    {
        totalField.text = playerStats.GetPlayerTotal().ToString();
    }
    
    public void SetActiveColor()
    {
        gameObject.GetComponent<Image>().color = currentPlayerColor;
    }
    
    public void SetPassiveColor()
    {
        gameObject.GetComponent<Image>().color = otherPlayersColor;
    }

    public void SetName(String str)
    {
        playerName.text = str;
    }
    
    /*private int ScoreFieldTextToIntParser(int i)
    {
        if (throwScoreFields[i].text == "X") return 10;
        if (throwScoreFields[i].text == "/")
        {
            return 10 - Int32.Parse(throwScoreFields[i - 1].text);
        }
        return Int32.Parse(throwScoreFields[i].text);
    }*/

    private String IntToScoreFieldText(int score, int scoreBefore)
    {
        if (score == 10 && throwNumber == 0) return "X";
        if (score == 10 && currentTurnIndex == 9) return "X";
        if (score + scoreBefore == 10) return "/";
        if (score == 0) return "-";
        return score.ToString();
    }
}
