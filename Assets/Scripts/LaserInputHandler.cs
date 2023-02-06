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
    private readonly Color hover = new(0.38f, 0.7f, 0.90f, 0.66f);
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
            Debug.Log("StartGameButton was clicked");
            mainMenu.StartGame();
        }

        else if (e.target.gameObject.CompareTag("PlusButton"))
        {
            Debug.Log("PlusButton was clicked");
            mainMenu.IncrementPlayerNumber();
        }
        else if (e.target.gameObject.CompareTag("MinusButton"))
        {
            Debug.Log("MinusButton was clicked");
            mainMenu.DecrementPlayerNumber();
        }
        else if (e.target.gameObject.CompareTag("BumpersToggle"))
        {
            Debug.Log("BumpersToggle was clicked");
            bumperToggle.isOn = !bumperToggle.isOn; ;
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject.CompareTag("StartGameButton") ||
            e.target.gameObject.CompareTag("MinusButton") ||
            e.target.gameObject.CompareTag("PlusButton") ||
            e.target.gameObject.CompareTag("PlusButton"))
        {
            Debug.Log("StartGameButton was entered");
            e.target.gameObject.GetComponent<Image>().color = hover;

        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject.CompareTag("StartGameButton") ||
            e.target.gameObject.CompareTag("MinusButton") ||
            e.target.gameObject.CompareTag("PlusButton") ||
            e.target.gameObject.CompareTag("PlusButton"))
        {
            e.target.gameObject.GetComponent<Image>().color = up;
            Debug.Log("StartGameButton was exited");
        }
    }
    
}
