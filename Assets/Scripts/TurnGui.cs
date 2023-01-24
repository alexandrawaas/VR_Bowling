using System;
using System.Collections;
using System.Collections.Generic;
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
    public void SetScore(int round, int throwNumber, int? score)
    {
        throwNumber = throwNumber - 1;
        round=round-1;
        
        if (round < 0 || round > 10 || throwNumber < 0 || (throwNumber > 2 && round < 10) || (throwNumber > 3 && round == 10))
        {
            throw new ArgumentException("Parameter out of range");
        }

        if (round == 10 && throwNumber == 3) throwScoreFields[^1].text = score.ToString();
        
        if(throwNumber == 0) 
        {
            throwScoreFields[round*2].text=score.ToString();
        }
        else if (throwNumber == 1)
        {
            throwScoreFields[round*2+1].text=score.ToString();
        }
        else if (throwNumber == 3)
        {
            throwScoreFields[round*2+2].text=score.ToString();
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
            roundTotalFields[i].text = (Int32.Parse(throwScoreFields[i * 2].text) + Int32.Parse(throwScoreFields[i * 2 + 1].text)).ToString();
        }
        roundTotalFields[^1].text =
            (Int32.Parse(throwScoreFields[(roundTotalFields.Length - 1) * 2].text) +
             Int32.Parse(throwScoreFields[((roundTotalFields.Length - 1) * 2) + 1].text) +
             Int32.Parse(throwScoreFields[((roundTotalFields.Length - 1) * 2) + 2].text)
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
    
    
    
    /*public void EndThrow()
    {
        if(currThrow == 2 && GameUIController.instance.round == 10 && (roundTotal + throwScore) == 10)
        {
            roundTotal += throwScore;
            roundTotalFields[GameUIController.instance.round-1].text = roundTotal.ToString();
            currScoreField++;
            currThrow++;
            
        }
        else if (currThrow < 1)
        {
            Debug.Log("First Throw");
            roundTotal += throwScore;
            roundTotalFields[GameUIController.instance.round-1].text = roundTotal.ToString();
            currScoreField++;
            currThrow++;
        } 
        else
        {
            Debug.Log("Turn Over");
            roundTotal += throwScore;
            roundTotalFields[GameUIController.instance.round-1].text = roundTotal.ToString();
            total += roundTotal;
            totalField.text = total.ToString();
            currScoreField++;
            currThrow = 0;
            roundTotal = 0;
			Debug.Log("Image:" + this.gameObject.GetComponent<Image>());
            gameObject.GetComponent<Image>().color = otherPlayersColor;
            GameUIController.instance.EndTurn();
        }
		
        throwScore = 0;
    }
    
    public void AddPoint()
    {
        throwScore ++;	
        throwScoreFields[currScoreField].text = throwScore.ToString();
    }*/
}
