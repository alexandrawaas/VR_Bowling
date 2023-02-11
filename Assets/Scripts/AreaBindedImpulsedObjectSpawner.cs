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
    [SerializeField] private Material[] ballColors;
    private int materialIndex = 0;
    
    private List<GameObject> spawnedObjects=new ();
    private List<GameObject> spawnedObjectsInTrigger = new();
    private List<GameObject> otherObjectsInTrigger = new();

    public bool isSpawnedObjectInTrigger
    {
        get { return spawnedObjectsInTrigger.Count > 0; }
    }
    
    
    public void SpawnBowlingBalls()
    {
        StartCoroutine(FillBalls(spawnObjectCount));
    }

    private IEnumerator FillBalls(int count)
    {
        for(int i = 0; i < count; i++)
        {
            GameObject newSpawnedObject = Instantiate(spawnObjectTemplate, spawnPositionMarkerObject.transform.position, Quaternion.identity);
            newSpawnedObject.GetComponent<Renderer>().material = ballColors[materialIndex < ballColors.Length ? materialIndex++ : materialIndex = 0];
            ImpulseObject(newSpawnedObject);
            yield return new WaitForSeconds(1);
            spawnedObjects.Add(newSpawnedObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        bool found = false;
        foreach(GameObject spawnObject in spawnedObjects)
        {
            if (other.gameObject == spawnObject)
            {
                spawnedObjectsInTrigger.Add(spawnObject);
                found = true;
            }
        }
        if(!found && other.gameObject.CompareTag("BowlingBall"))
        {
            if (spawnedObjects.Count < 6) spawnedObjects.Add(other.gameObject);
            spawnedObjectsInTrigger.Add(other.gameObject);
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

    public void SpawnBall()
    {
        StartCoroutine(FillBalls(1));
    }
    
    public void ResetBall(GameObject ball)
    {
        ball.transform.position = spawnPositionMarkerObject.transform.position;
        ImpulseObject(ball);
    }
}
