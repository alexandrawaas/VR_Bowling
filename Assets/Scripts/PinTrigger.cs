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
            fallenPins++;
            ScoreManager.instance.AddPoint();
            hasFallen = true;
            Debug.Log("Fallen Pins: " + fallenPins);
        }
    }
}
