using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class LaneObjectDespawner : MonoBehaviour
{
    private List<GameObject> objectsInTrigger = new();
    [SerializeField] private AreaBindedImpulsedObjectSpawner areaBindedImpulsedObjectSpawner;

    public bool isObjectInTrigger
    {
        get { return objectsInTrigger.Count > 0; }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Pin>() == null)
        {
            objectsInTrigger.Add(other.gameObject);
        }
    }

    public void RemoveAllObjectsInTrigger()
    {
        foreach (GameObject objectInTrigger in objectsInTrigger)
        {
            if (objectInTrigger.CompareTag("BowlingBall"))
            {
                StartCoroutine(ResetBall(objectInTrigger));
            }
            else
            {
                Destroy(objectInTrigger, 2);
            }
        }
    }

    public IEnumerator ResetBall(GameObject ball)
    {
        areaBindedImpulsedObjectSpawner.ResetBall(ball);
        yield return new WaitForSeconds(3);
    }

}
