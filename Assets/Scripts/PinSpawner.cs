using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PinSpawner : MonoBehaviour
{
    public GameObject spawnItem;
    private Vector3 position;
    private Quaternion quaternion;

    public static float despawnTime;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        Debug.Log("Pin Spawned");
    }

    public void Spawn()
     {
         GameObject newSpawnedObject = Instantiate(spawnItem, transform.position, Quaternion.identity);
         newSpawnedObject.transform.parent = transform;
     }
}
