using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnGui : MonoBehaviour
{
    //Single Throws, Round Total and Player Total. Counter of first two is reset to 0 after throw / round.
    [SerializeField] private TMP_Text[] throwScoreFields;
    [SerializeField] private TMP_Text[] roundTotalFields;
    [SerializeField] private TMP_Text totalField;
    
    //score=null is spare slash
    public void SetScore(int round, int throwNumber, int? fallenPins, int scoreBefore)
    {
        throwNumber = throwNumber - 1;
        round=round-1;
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

        if (round < 0 || round > 10 || throwNumber < 0 || (throwNumber > 2 && round < 10) || (throwNumber > 3 && round == 10))
        {
            throw new ArgumentException("Parameter out of range");
        }

        if (round == 10 && throwNumber == 3) throwScoreFields[^1].text = IntToScoreFieldText(score, scoreBefore);
        
        if(throwNumber == 0) 
        {
            throwScoreFields[round*2].text=IntToScoreFieldText(score, scoreBefore);
        }
        else if (throwNumber == 1)
        {
            throwScoreFields[round*2+1].text=IntToScoreFieldText(score, scoreBefore);
        }
        else if (throwNumber == 3)
        {
            throwScoreFields[round*2+2].text=IntToScoreFieldText(score, scoreBefore);
        }
        
        UpdateAllFields();
    }

    public void UpdateAllFields()
    {
        UpdateRoundFields();
        UpdateTotalField();
    }
    
    private void UpdateRoundFields()
    {
        for (int i = 0; i <= roundTotalFields.Length-2; i++)
        {
            roundTotalFields[i].text = (ScoreFieldTextToIntParser(i * 2) + ScoreFieldTextToIntParser(i * 2 + 1)).ToString();
        }
        roundTotalFields[^1].text =
            (ScoreFieldTextToIntParser((roundTotalFields.Length - 1) * 2) +
             ScoreFieldTextToIntParser((roundTotalFields.Length - 1) * 2 + 1) +
             ScoreFieldTextToIntParser((roundTotalFields.Length - 1) * 2 + 2)
            ).ToString();
    }

    private void UpdateTotalField()
    {
        int result = 0;
        
        foreach (TMP_Text roundTotalField in roundTotalFields)
        {
            result += Int32.Parse(roundTotalField.text);
        }

        totalField.text = result.ToString();
    }
    
    public void SetColor(Color color)
    {
        gameObject.GetComponent<Image>().color = color;
    }

    private int ScoreFieldTextToIntParser(int i)
    {
        if (throwScoreFields[i].text == "X") return 10;
        if (throwScoreFields[i].text == "/")
        {
            return 10 - Int32.Parse(throwScoreFields[i - 1].text);
        }
        return Int32.Parse(throwScoreFields[i].text);
    }

    private String IntToScoreFieldText(int score, int scoreBefore)
    {
        if (score == 10) return "X";
        if (score + scoreBefore == 10) return "/";
        return score.ToString();
    }
}
