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
    [SerializeField] private GameObject bumperToggle;
    [SerializeField] private GameObject confirmRestartPanel;
    [SerializeField] private GameObject confirmQuitPanel;
    [SerializeField] private TMP_Text playerNumberLabel;
    [SerializeField] private GameObject bumpers;
    private int playerNumber = 1;

    public void Start()
    {
        bumpers.SetActive(false);
        bowlingController.ClosePinSetter();
        Debug.Log("Bumpers are inactive");
    }

    public void UpdatePlayersNumber()
    {
        playerNumberLabel.text = playerNumber.ToString();
    }

    public void ToggleBumpers()
    {
        Debug.Log("Bumpers are "+bumperToggle.GetComponent<Toggle>().isOn);
        bumpers.SetActive(bumperToggle.GetComponent<Toggle>().isOn);
        Debug.Log("Bumpers are "+bumperToggle.GetComponent<Toggle>().isOn);
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
    
    public void ConfirmQuit()
    {
        restartPanel.SetActive(false);
        confirmQuitPanel.SetActive(true);
    }

    public void AbortQuit()
    {
        confirmQuitPanel.SetActive(false);
        restartPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void changeGui()
    {
        settingsPanel.SetActive(false);
        restartPanel.SetActive(true);
    }
}
