using System;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private Vector3 position;
    private Quaternion rotation;
    private GameObject pin;
    public bool hasFallen { get; private set; } = false ;
    private AudioSource audioSource;

    void Start()
    {
        pin = gameObject;
        position = pin.transform.position;
        rotation = pin.transform.rotation;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0.9f;
        audioSource.clip = Resources.Load<AudioClip>("PinFall");
    }
    
    private void FixedUpdate()
    {
        if (!hasFallen && (Math.Abs(pin.transform.rotation.eulerAngles.z) > 70 || Math.Abs(pin.transform.rotation.eulerAngles.x) > 70))
        {
                hasFallen = true;
                Debug.Log(pin.name+" has fallen");
                audioSource.Play();
        }
    }

    public void Hide()
    {
        pin.SetActive(false);
    }

    public void Reset()
    {
        var pinRigidbody = pin.GetComponent<Rigidbody>();
        pin.transform.position = position;
        pin.transform.rotation = rotation;
        pinRigidbody.Sleep();
        gameObject.SetActive(true);
        pinRigidbody.WakeUp();
        hasFallen = false;
    }

    public void ResetBooleanFallen()
    {
        hasFallen = false;
    }
}
