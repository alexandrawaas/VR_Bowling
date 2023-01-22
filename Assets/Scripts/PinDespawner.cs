using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinDespawner : MonoBehaviour
{
	public PinSpawner[] pinSpawners;
	private GameObject pin;

    public void DespawnFallen()
    {
		foreach(PinSpawner pinSpawner in pinSpawners)		
		{
			if(pinSpawner.transform.childCount != 0) 
			{
				pin = pinSpawner.transform.GetChild(0).gameObject;	
				Debug.Log("Despawner" + pin.GetComponent<Pin>().hasFallen);
				if (pin.GetComponent<Pin>().hasFallen == true) Destroy(pinSpawner.transform.GetChild(0).gameObject, 5f);
			}
		}
    }

	public void DespawnAll()
    {
		foreach(PinSpawner pinSpawner in pinSpawners)		
		{
			if(pinSpawner.transform.childCount != 0) 
			{
				Destroy(pinSpawner.transform.GetChild(0).gameObject);
			}
		}
    }
	
	public void SpawnAll()
	{
		foreach(PinSpawner pinSpawner in pinSpawners)		
		{
			if(pinSpawner.transform.childCount == 0) 
			{
				pinSpawner.Spawn();
			}
		}
	}

	public void ResetFallen()
	{
		foreach(PinSpawner pinSpawner in pinSpawners)		
		{
			if(pinSpawner.transform.childCount != 0) 
			{
				pin = pinSpawner.transform.GetChild(0).gameObject;	
				if (pin.GetComponent<Pin>().hasFallen == true) pin.GetComponent<Pin>().hasFallen = false;
			}
		}
	}
	
}