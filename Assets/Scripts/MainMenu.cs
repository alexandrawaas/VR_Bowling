using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private BowlingController bowlingController;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private GameObject confirmRestartPanel;
    [SerializeField] private TMP_Text playerNumberLabel;
    [SerializeField] public  Toggle bumperToggle { get; private set; }
    [SerializeField] private GameObject bumpers;
    private bool gameIsRunning = false;
    private int playerNumber = 1;

    public void Start()
    {
        bumpers.SetActive(false);
    }

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
        gameIsRunning = true;
        changeGui();
    }

    public void ConfirmRestart()
    {
        restartPanel.SetActive(false);
        confirmRestartPanel.SetActive(true);
    }

    public void AbortRestart()
    {
        confirmRestartPanel.SetActive(false);
        restartPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void changeGui()
    {
        settingsPanel.SetActive(false);
        restartPanel.SetActive(true);
    }
}
