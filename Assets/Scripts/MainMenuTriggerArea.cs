using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;

public class MainMenuTriggerArea : MonoBehaviour
{
    [SerializeField] private SteamVR_LaserPointer laserPointer;

    private void OnTriggerEnter(Collider other)
    {
       
      
            laserPointer.gameObject.GetComponent<SteamVR_LaserPointer>().enabled = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
            laserPointer.gameObject.GetComponent<SteamVR_LaserPointer>().enabled = false;
        
    }
    
}
