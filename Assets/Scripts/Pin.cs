using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public static int fallenPins = 0;
    public bool hasFallen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MeshCollider>() != null)
        {
            if (!hasFallen)
            {
                fallenPins++;
                GameUIController.instance.currPlayer.AddPoint();
            }
            hasFallen = true;
            Debug.Log("Fallen Pins: " + fallenPins);
        }
    }
}
