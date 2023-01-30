using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredLight : MonoBehaviour
{
    private readonly Color greenLightColor = new (0f, 1f, 0f, 1f);
    private readonly Color redLightColor = new (1f, 0f, 0f, 1f);
    public void ChangeToGreen()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor",greenLightColor);
        gameObject.GetComponent<Renderer>().material.color = greenLightColor;
    }
    
    public void ChangeToRed()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor",redLightColor);
        gameObject.GetComponent<Renderer>().material.color = redLightColor;
    }
}
