using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;

public class LaserInputHandler : MonoBehaviour
{
    [SerializeField] private SteamVR_LaserPointer laserPointer;
    
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
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject.CompareTag("StartGameButton"))
        {
            Debug.Log("StartGameButton was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject.CompareTag("StartGameButton"))
        {
            Debug.Log("StartGameButton was exited");
        }
    }
    
}
