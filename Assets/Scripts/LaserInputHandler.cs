using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;

public class LaserInputHandler : MonoBehaviour
{
    [SerializeField] private SteamVR_LaserPointer laserPointer;
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private Toggle bumperToggle;
    private readonly Color hover = new(0.61f, 0.57f, 0.91f, 0.66f);
    private readonly Color up = new(0.38f, 0.31f, 0.90f, 0.66f);

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject.CompareTag("StartGameButton"))
        {
            mainMenu.StartGame();
        }
        else if (e.target.gameObject.CompareTag("PlusButton"))
        {
            mainMenu.IncrementPlayerNumber();
        }
        else if (e.target.gameObject.CompareTag("MinusButton"))
        {
            mainMenu.DecrementPlayerNumber();
        }
        else if (e.target.gameObject.CompareTag("BumpersToggle"))
        {
            bumperToggle.isOn = !bumperToggle.isOn; ;
        }
        else if (e.target.gameObject.CompareTag("OpenConfirmButton"))
        {
            mainMenu.ConfirmRestart();
        }
        else if (e.target.gameObject.CompareTag("ConfirmNoButton"))
        {
            mainMenu.AbortRestart();
        }
        else if (e.target.gameObject.CompareTag("ConfirmYesButton"))
        {
            mainMenu.Restart();
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject.CompareTag("StartGameButton") ||
            e.target.gameObject.CompareTag("MinusButton") ||
            e.target.gameObject.CompareTag("PlusButton") ||
            e.target.gameObject.CompareTag("OpenConfirmButton") ||
            e.target.gameObject.CompareTag("ConfirmNoButton") ||
            e.target.gameObject.CompareTag("ConfirmYesButton"))
        {
            e.target.gameObject.GetComponent<Image>().color = hover;

        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject.CompareTag("StartGameButton") ||
            e.target.gameObject.CompareTag("MinusButton") ||
            e.target.gameObject.CompareTag("PlusButton") ||
            e.target.gameObject.CompareTag("OpenConfirmButton") ||
            e.target.gameObject.CompareTag("ConfirmNoButton") ||
            e.target.gameObject.CompareTag("ConfirmYesButton"))
        {
            e.target.gameObject.GetComponent<Image>().color = up;
        }
    }
    
}
