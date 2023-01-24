using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsManager : MonoBehaviour
{
	public List<Pin> pins=new ();

	public int fallenPins
	{
		get
		{
			int result = 0;
			foreach (var pin in pins)
			{
				if (pin.hasFallen) result++;
			}

			return result;
		}
	}
	
	
	private void Update()
	{
		/*if (Input.GetKeyDown(KeyCode.A))
		{
			HideFallen();
		}
		
		if (Input.GetKeyDown(KeyCode.S))
		{
			ResetAll();
		}*/
	}

	public void HideFallen()
	{
		foreach (Pin pin in pins) if(pin.hasFallen) pin.Hide();
	}

	public void ResetAll()
	{
		foreach (Pin pin in pins) pin.Reset();
	}
	
	public void ResetBooleanFallen()
	{
		foreach (Pin pin in pins) pin.ResetBooleanFallen();
	}
}