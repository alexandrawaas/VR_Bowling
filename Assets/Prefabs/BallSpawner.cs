using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject spawnItem;

    public float rollBackTime;
    public static float despawnTime;

    public float initialSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Spawn()
    {
        GameObject newSpawnedObject = Instantiate(spawnItem, transform.position, Quaternion.identity);
        newSpawnedObject.GetComponent<Rigidbody>().velocity = transform.forward * initialSpeed;
        newSpawnedObject.transform.parent = transform;
    }
}
