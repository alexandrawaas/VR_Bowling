using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	/*public static ScoreManager instance;
	public PinSpawner pinSpawner;

	private int round = 1;
	public TMP_Text[] scoreFields;
	public TMP_Text[] totalFields;

	private int currPoints = 0;
	private int roundTotal = 0;

	private int currScoreField = 0;

	private void Awake() 
	{
		instance = this;
	}

    // Start is called before the first frame update
    void Start()
    {
        scoreFields[currScoreField].text = currPoints.ToString();
    }

    public void AddPoint()
	{
		currPoints ++;	
		scoreFields[currScoreField].text = currPoints.ToString();
	}

	public void EndThrow()
	{
		if(currScoreField<2)
		{
			roundTotal += currPoints;
			totalFields[round-1].text = scoreFields[currScoreField].text;
			PinTrigger.fallenPins = 0;
			currScoreField++;
		}
		else
		{
			EndRound();
			currScoreField = 0;
		}
		
		currPoints = 0;
		pinSpawner.Spawn();
	}

	private void EndRound() 
	{
		roundTotal = 0;
		round++;
	}*/
}
