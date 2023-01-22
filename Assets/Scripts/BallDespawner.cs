using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDespawner : MonoBehaviour
{
    public BallSpawner spawner;
	public PinDespawner pinDespawner;
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallIdentifier>() != null)
        {
            StartCoroutine(DestroyBall(other));
            spawner.Spawn();
        }
    }

    private IEnumerator DestroyBall(Collider other)
    {
        Destroy(other.gameObject, 15f);
        yield return new WaitForSeconds(15);
		pinDespawner.DespawnFallen();
        GameUIController.instance.currPlayer.EndThrow();
        Debug.Log("nextThrow");
		pinDespawner.ResetFallen();
    }
}