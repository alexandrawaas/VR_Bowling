using Unity.VisualScripting;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private Vector3 position;
    private Quaternion rotation;
    private GameObject pin;
    public bool hasFallen { get; private set; } = false ;

    void Start()
    {
        pin = gameObject;
        position = pin.transform.position;
        rotation = pin.transform.rotation;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<AreaBindedImpulsedObjectSpawner>() == null)
        {
            if (!hasFallen) hasFallen = true;
            //Debug.Log("Pin" + gameObject.name + " has fallen because of " + other.gameObject.name);
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
