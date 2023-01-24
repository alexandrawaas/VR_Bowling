using UnityEngine;

public class Pin : MonoBehaviour
{
    private Vector3 position;
    private Quaternion rotation;
    public bool hasFallen { get; private set; } = false ;

    void Start()
    {
        position = gameObject.transform.position;
        rotation = gameObject.transform.rotation;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Pin>() == null && other.GetComponent<SphereCollider>() == null)
        {
            if (!hasFallen) hasFallen = true;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        gameObject.transform.position = position;
        gameObject.transform.rotation = rotation;
        gameObject.GetComponent<Rigidbody>().Sleep();
        gameObject.SetActive(true);
        gameObject.GetComponent<Rigidbody>().WakeUp();
        hasFallen = false;
    }

    public void ResetBooleanFallen()
    {
        hasFallen = false;
    }
}
