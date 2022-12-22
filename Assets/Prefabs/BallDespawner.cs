using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDespawner : MonoBehaviour
{
    public BallSpawner Spawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SphereCollider>() != null)
        {
            Destroy(other.gameObject);
            Spawner.Spawn();
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
