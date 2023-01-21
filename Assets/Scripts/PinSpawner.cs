using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    public GameObject spawnItem;
    
    public static float despawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        Debug.Log("Pins Spawned");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Spawn()
    {
        GameObject newSpawnedObject = Instantiate(spawnItem, transform.position, Quaternion.identity);
        newSpawnedObject.transform.parent = transform;
    }
}
