using System.Collections;
using UnityEngine;

public class BowlingController : MonoBehaviour
{
	[SerializeField] private PinsManager pinsManager;
    [SerializeField] private AreaBindedImpulsedObjectSpawner areaBindedImpulsedObjectSpawner;
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
	    isThrowEnded = true;
	    ampel.ChangeToRed();
	    yield return new WaitForSeconds(8);
	    
	    pinsManager.HideFallen();
	    gameState.SetScore(pinsManager.fallenPins);
	    gui.SetScore(pinsManager.fallenPins);
	    gameState.GetCurrentPlayersTurn().IncreaseThrowNumber();
	    
	    //Handle Turn End after Strike
	    if(gameState.GetCurrentPlayersTurn().isStrike) gameState.GetCurrentPlayersTurn().IncreaseThrowNumber();
	    
	    pinsManager.ResetBooleanFallen();
	    ampel.ChangeToGreen();
	    Debug.Log("Reached Point, Strike is "+gameState.GetCurrentPlayersTurn().isStrike);
	    if (gameState.GetCurrentPlayersTurn().currentThrow > 1 && gameState.currentRound < 10 ||
	        gameState.GetCurrentPlayersTurn().currentThrow == 2 && gameState.currentRound == 10)
	    {
		    EndTurn();
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
