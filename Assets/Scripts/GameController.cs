using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PinsManager pinsManager;
    [SerializeField] private AreaBindedImpulsedObjectSpawner areaBindedImpulsedObjectSpawner;
    [SerializeField] private int playersNumber;
    [SerializeField] private TurnGui turnGuiPrefab;
    [SerializeField] private Ampel ampel;

    private List<TurnGui> players = new ();
    private int currentPlayerIndex = 0;
    private int currentRound = 1;
    private int currentThrow = 1;
    private readonly Color currentPlayerColor = new (0.31f, 0.65f, 0.86f, 0.7803922f);
    private readonly Color otherPlayersColor = new (0.61f, 0.68f, 0.72f, 0.7803922f);
    private readonly Color greenLightColor = new (0f, 1f, 0f, 1f);
    private readonly Color redLightColor = new (1f, 0f, 0f, 1f);
    private bool isThrowEnded = false;
    private int scoreBefore = 0;



    private void Update()
    {
        if(areaBindedImpulsedObjectSpawner.isSpawnedObjectInTrigger)
        {
            if (!isThrowEnded) StartCoroutine(EndThrow());
            StartCoroutine(ResetBalls());
        }
    }

    private IEnumerator ResetBalls()
    {
        yield return new WaitForSeconds(5);
        areaBindedImpulsedObjectSpawner.ResetAllBallsInTrigger();
        isThrowEnded = false;
    }

    private IEnumerator EndThrow()
    {
        Debug.Log("Throw ended");
        ampel.SetColor(redLightColor);
        isThrowEnded = true;
        yield return new WaitForSeconds(15);
        pinsManager.HideFallen();
        players[currentPlayerIndex].SetScore(currentRound, currentThrow, pinsManager.fallenPins);
        if (pinsManager.fallenPins == 10 && currentThrow == 1 || currentThrow == 3)
        {
            Debug.Log("Strike!");
            currentThrow++;
        }
        if (pinsManager.fallenPins + scoreBefore == 10)
        {
            Debug.Log("Spare!");
        }
        scoreBefore = pinsManager.fallenPins;
        pinsManager.ResetBooleanFallen();
        currentThrow++;
        ampel.SetColor(greenLightColor);
        if (currentThrow > 2 && currentRound < 10 || currentThrow == 3 && currentRound == 10) EndTurn();
        //if (currentRound > 10 && currentThrow > 3) EndGame();
    }


    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playersNumber; i++)
        {
            AddPlayer();
        }
		players[currentPlayerIndex].SetColor(currentPlayerColor);
    }


    public void AddPlayer()
    {
        TurnGui player = Instantiate(turnGuiPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
        Debug.Log(player);
        player.transform.SetParent(this.gameObject.transform, false);
        players.Add(player);
    }
    
    public void EndTurn() 
    {
        Debug.Log("Turn ended");
        pinsManager.HideFallen();
        pinsManager.ResetAll();
        players[currentPlayerIndex].SetColor(otherPlayersColor);
        currentPlayerIndex++;
        currentThrow = 1;
        if (currentPlayerIndex > players.Count - 1)
        {
            EndRound();
        }
        else
        {
            Debug.Log("Player" + (currentPlayerIndex + 1) + " ist dran");
            players[currentPlayerIndex].SetColor(currentPlayerColor);
        }
    }
    private void EndRound() 
    {
        Debug.Log("Round ended");
        currentRound++;
        if (currentRound > 10)
        {
            EndGame();
        }
        else
        {
            currentPlayerIndex = 0;
            players[currentPlayerIndex].SetColor(currentPlayerColor);
        }
    }

    private void EndGame()
    {
        Debug.Log("Player " + GetWinner() + " hat gewonnen.");
    }

    private String GetWinner()
    {
        //TODO calculate Winner
        return "X"; 
    }
}