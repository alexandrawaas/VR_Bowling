using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinTrigger : MonoBehaviour
{
    public GameObject collisionObject;
    public static int fallenPins = 0;
    public bool hasFallen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other == collisionObject.GetComponent<MeshCollider>())
        {
            Debug.Log("Pin has fallen");
            fallenPins++;
            hasFallen = true;
            Debug.Log("Fallen Pins: " + fallenPins);
        }
    }
}
