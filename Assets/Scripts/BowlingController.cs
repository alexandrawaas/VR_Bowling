using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Video;

public class BowlingController : MonoBehaviour
{
	[SerializeField] private PinsManager pinsManager;
    [SerializeField] private AreaBindedImpulsedObjectSpawner areaBindedImpulsedObjectSpawner;
    [SerializeField] private LaneObjectDespawner objectsOnLaneDespawner;
    [SerializeField] private ColoredLight ampel;
    [SerializeField] private PinSetter pinSetter;
    [SerializeField] private PlayerGui playerGuiPrefab;
    [SerializeField] private GameObject screen;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSourceWon;
    [SerializeField] private VideoPlayer videoPlayerStrike;
    [SerializeField] private VideoPlayer videoPlayerSpare;
    [SerializeField] private VideoPlayer videoPlayerWon;
    [SerializeField] private GameObject winnerScreen;

    private GameState gameState;
    private ScreenGui gui;
    private bool isThrowEnded = false;

    public void Awake()
    {
	    pinSetter.SinkDown();
    }

    public void StartNewBowlingGame(int playersNumber)
	{
		gameState = new GameState(playersNumber);
	    gui = new ScreenGui(playersNumber, gameState, playerGuiPrefab, screen);
	    areaBindedImpulsedObjectSpawner.SpawnBowlingBalls();
	    pinSetter.ResetPosition();
    }

    private void Update()
    {
	    if(areaBindedImpulsedObjectSpawner.isSpawnedObjectInTrigger)
	    {
		    if (!isThrowEnded) StartCoroutine(EndThrow());
		    StartCoroutine(ResetBallsAfterThrow());
	    }
    }

    private IEnumerator ResetBallsAfterThrow()
    {
	    yield return new WaitForSeconds(2);
	    areaBindedImpulsedObjectSpawner.ResetAllBallsInTrigger();
	    isThrowEnded = false;
    }

    private IEnumerator EndThrow()
    {
	    Debug.Log("Throw ended");
	    isThrowEnded = true;
	    ampel.ChangeToRed();
	    yield return new WaitForSeconds(0.5f);
	    pinSetter.SinkDown();
	    yield return new WaitForSeconds(4);
	    
	    pinsManager.HideFallen();

	    var score = pinsManager.fallenPins;
	    gameState.SetScore(score);
	    gui.SetScore(score);
	    if (gameState.GetCurrentPlayersTurn().isSpare)
	    {
		    audioSource.Play();
		    videoPlayerSpare.gameObject.SetActive(true);
		    videoPlayerSpare.Play();
		    yield return new WaitForSeconds(8);
		    videoPlayerSpare.gameObject.SetActive(false);
	    }
	    if (gameState.GetCurrentPlayersTurn().isStrike)
	    {
		    audioSource.Play();
		    videoPlayerStrike.gameObject.SetActive(true);
		    videoPlayerStrike.Play();
		    yield return new WaitForSeconds(8);
		    videoPlayerStrike.gameObject.SetActive(false);
	    }

	    yield return new WaitForSeconds(3);
	    gameState.GetCurrentPlayersTurn().IncreaseThrowNumber();
	    Debug.Log("ThrowNumber: "+gameState.GetCurrentPlayersTurn().currentThrow);
	    
	    //Handle Turn End after Strike
	    if(gameState.GetCurrentPlayersTurn().isStrike && gameState.currentRound < 10) gameState.GetCurrentPlayersTurn().IncreaseThrowNumber();
	    
	    pinsManager.ResetBooleanFallen();
	    pinSetter.ResetPosition();
	    ampel.ChangeToGreen();
	    Debug.Log("Total: "+gameState.GetCurrentPlayersTurn().total);
	    if (gameState.GetCurrentPlayersTurn().currentThrow > 1 && gameState.currentRound < 10 ||
	        gameState.GetCurrentPlayersTurn().currentThrow > 2 && gameState.currentRound == 10 ||
	        gameState.GetCurrentPlayersTurn().currentThrow > 1 && gameState.currentRound == 10 && gameState.GetCurrentPlayersTurn().total < 10)
	    {
		    EndTurn();
	    }

	    if (gameState.currentRound == 10 &&
	        (score == 10 || gameState.GetCurrentPlayersTurn().isSpare))
	    {
		    pinsManager.HideFallen();
		    pinsManager.ResetAll();
	    }
    }

    
    private void EndTurn()
    {
	    Debug.Log("Turn ended");
	    pinsManager.HideFallen();
	    pinsManager.ResetAll();
	    gui.ChangeToNextPlayer(gameState.currentPlayer);
	    if (gameState.StartNextPlayersTurn() == false)
	    {
		    EndGame();
	    }
	    else
	    {
		    Debug.Log("Player" + (gameState.currentPlayer + 1) + " ist dran");
	    }
    }
    
    private void EndGame()
    {
	    pinSetter.SinkDown();
	    Debug.Log(gameState.GetWinner() + " hat gewonnen.");
	    videoPlayerWon.gameObject.SetActive(true);
	    audioSourceWon.Play();
	    videoPlayerWon.Play();
	    winnerScreen.GetComponentInChildren<TMP_Text>().SetText(gameState.GetWinner() + " hat gewonnen!");
	    winnerScreen.SetActive(true);
    }


}
