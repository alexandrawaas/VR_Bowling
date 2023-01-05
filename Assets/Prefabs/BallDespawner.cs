using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDespawner : MonoBehaviour
{
    public BallSpawner Spawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallIdentifier>() != null)
        {
            Destroy(other.gameObject, 10f);
            Debug.Log("Ball collided with despawner");
            Spawner.Spawn();
        }
    }
}
