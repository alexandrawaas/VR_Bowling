using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDespawner : MonoBehaviour
{
    public BallSpawner Spawner;
	public PinSpawner pinSpawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallIdentifier>() != null)
        {
            StartCoroutine(DestroyBall(other));
            Spawner.Spawn();
        }
    }

    private IEnumerator DestroyBall(Collider other)
    {
        Destroy(other.gameObject, 5f);
		Destroy(pinSpawner.transform.GetChild(0).gameObject, 5f);
        yield return new WaitForSeconds(5);
        ScoreManager.instance.EndThrow();
        Debug.Log("nextThrow");
    }
}