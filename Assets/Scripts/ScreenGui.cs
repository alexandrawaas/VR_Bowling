using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenGui
{
    private PlayerGui[] playerGuis;
    private GameState gameState;

    public ScreenGui(int playerNumber, GameState gameState, PlayerGui playerGuiPrefab, GameObject screen)
    {
        this.gameState = gameState;
        playerGuis = new PlayerGui[playerNumber];
        for(var i = 0; i < playerNumber; i++)
        {
            playerGuis[i] = UnityEngine.Object.Instantiate(playerGuiPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
            playerGuis[i].transform.SetParent(screen.transform, false); 
        }
        playerGuis[0].SetActiveColor();
        UpdateGui();
    }

    public void SetScore(int score)
    {
        playerGuis[gameState.currentPlayer].SetScore(gameState.currentRound-1, gameState.GetCurrentPlayersTurn(), score);
        UpdateGui();
    }

    public void UpdateGui()
    {
        for(int i=0; i<playerGuis.Length; i++)
        {
            playerGuis[i].UpdateAllFields(gameState, i);
        }
    }

    public void ChangeToNextPlayer(int index)
    {
        playerGuis[index].SetPassiveColor();
        playerGuis[index+1>=playerGuis.Length? 0 : (index+1)].SetActiveColor();
    }
}
