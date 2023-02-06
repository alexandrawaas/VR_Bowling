using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private BowlingController bowlingController;
    [SerializeField] private Slider playerSlider;
    [SerializeField] private TMP_Text playerNumberLabel;
    [SerializeField] public  Toggle bumperToggle { get; private set; }
    [SerializeField] private GameObject bumpers;
    private int playerNumber = 1;

    public void UpdatePlayersNumber()
    {
        playerNumberLabel.text = playerNumber.ToString();
    }

    public void ToggleBumpers()
    {
        bumpers.SetActive(bumperToggle.isOn);
    }

    public void IncrementPlayerNumber()
    {
        if(playerNumber < 6) playerNumber++;
        UpdatePlayersNumber();
    }

    public void DecrementPlayerNumber()
    {
        if (playerNumber > 1) playerNumber--;
        UpdatePlayersNumber() ;
    }

    public void StartGame()
    {
        bowlingController.StartNewBowlingGame(playerNumber);
    }
}
