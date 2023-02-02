using System.Collections;
using UnityEngine;

public class BowlingController : MonoBehaviour
{
	[SerializeField] private PinsManager pinsManager;
    [SerializeField] private AreaBindedImpulsedObjectSpawner areaBindedImpulsedObjectSpawner;
    [SerializeField] private LaneObjectDespawner objectsOnLaneDespawner;
    [SerializeField] private int playersNumber;
    [SerializeField] private ColoredLight ampel;
    [SerializeField] private PlayerGui playerGuiPrefab;
    [SerializeField] private GameObject screen;

    private GameState gameState;
    private ScreenGui gui;
    private bool isThrowEnded = false;

	void Start()
    {
	    gameState = new GameState(playersNumber);
	    gui = new ScreenGui(playersNumber, gameState, playerGuiPrefab, screen);
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
	    yield return new WaitForSeconds(5);
	    areaBindedImpulsedObjectSpawner.ResetAllBallsInTrigger();
	    isThrowEnded = false;
    }

    private IEnumerator EndThrow()
    {
	    Debug.Log("Throw ended");
	    isThrowEnded = true;
	    ampel.ChangeToRed();
	    yield return new WaitForSeconds(8);
	    
	    pinsManager.HideFallen();

	    var score = pinsManager.fallenPins;
	    gameState.SetScore(score);
	    gui.SetScore(score);
	    gameState.GetCurrentPlayersTurn().IncreaseThrowNumber();
	    Debug.Log("ThrowNumber: "+gameState.GetCurrentPlayersTurn().currentThrow);
	    
	    //Handle Turn End after Strike
	    if(gameState.GetCurrentPlayersTurn().isStrike) gameState.GetCurrentPlayersTurn().IncreaseThrowNumber();
	    
	    pinsManager.ResetBooleanFallen();
	    ampel.ChangeToGreen();
	    Debug.Log("Reached Point, Strike is "+gameState.GetCurrentPlayersTurn().isStrike);
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
	    Debug.Log(gameState.GetWinner() + " hat gewonnen.");
    }


}
