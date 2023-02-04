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
    [SerializeField] private Toggle bumperToggle;
    [SerializeField] private GameObject bumpers;

    public void SetPlayersNumber()
    {
        playerNumberLabel.text = playerSlider.value.ToString();
    }

    public void ToggleBumpers()
    {
        bumpers.SetActive(bumperToggle.isOn);
    }

    public void StartGame()
    {
        bowlingController.StartNewBowlingGame((int)playerSlider.value);
    }
}
