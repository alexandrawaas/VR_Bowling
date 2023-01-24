using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ampel : MonoBehaviour
{
    public void SetColor(Color newColor)
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor",newColor);
        gameObject.GetComponent<Renderer>().material.color = newColor;
    }
}
