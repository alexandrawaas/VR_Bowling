using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AreaBindedImpulsedObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnObjectTemplate;
    [SerializeField] private GameObject spawnPositionMarkerObject;
    [SerializeField] private Vector3 spawnDirection;
    [SerializeField] private float spawnImpulseSpeed;
    [SerializeField] private int spawnObjectCount;
    
    private List<GameObject> spawnedObjects=new ();
    private List<GameObject> spawnedObjectsInTrigger = new();

    public bool isSpawnedObjectInTrigger
    {
        get { return spawnedObjectsInTrigger.Count > 0; }
    }
    
    
    void Start()
    {
        StartCoroutine(FillBalls());
    }

    private IEnumerator FillBalls()
    {
        for(int i = 0; i < spawnObjectCount; i++)
        {
            GameObject newSpawnedObject = Instantiate(spawnObjectTemplate, spawnPositionMarkerObject.transform.position, Quaternion.identity);
            ImpulseObject(newSpawnedObject);
            yield return new WaitForSeconds(1);
            spawnedObjects.Add(newSpawnedObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        foreach(GameObject spawnObject in spawnedObjects)
        {
            if (other.gameObject == spawnObject)
            {
                spawnedObjectsInTrigger.Add(spawnObject);
            }
        }
    }

    public void ResetAllBallsInTrigger()
    {
        foreach (GameObject spawnObjectInTrigger in spawnedObjectsInTrigger)
        {
            spawnObjectInTrigger.transform.position = spawnPositionMarkerObject.transform.position;
            ImpulseObject(spawnObjectInTrigger);
            spawnedObjectsInTrigger.Remove(spawnObjectInTrigger);
        }
    }

    private void ImpulseObject(GameObject impulsedObject)
    {
        impulsedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        impulsedObject.GetComponent<Rigidbody>().velocity = transform.forward * spawnImpulseSpeed;
    }
}
