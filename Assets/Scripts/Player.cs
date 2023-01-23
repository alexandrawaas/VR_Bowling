using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    //Single Throws, Round Total and Player Total. Counter of first two is reset to 0 after throw / round.
    public TMP_Text[] throwScoreFields;
    private int throwScore = 0;
    public TMP_Text[] roundTotalFields;
    private int roundTotal = 0;
    public TMP_Text totalField;
    private int total = 0;

    //Index of current throw in all throws
    private int currThrow = 0;
    private int currScoreField = 0;
	private Color otherPlayersColor = new Color(0.35f, 0.62f, 0.79f, 0.7803922f);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void EndThrow()
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
    }

	public void SetActiveColor(Color color)
	{
		gameObject.GetComponent<Image>().color = color;
	}
}
