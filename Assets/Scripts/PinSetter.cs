using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PinSetter : MonoBehaviour
{
    private Vector3 standardPosition;

    private void Start()
    {
        standardPosition = gameObject.transform.position;
    }

    public void SinkDown()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    public void ResetPosition()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.transform.position = standardPosition;
    }
}
