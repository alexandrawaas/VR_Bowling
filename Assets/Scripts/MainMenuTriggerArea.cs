
using UnityEngine;

using Valve.VR.Extras;

public class MainMenuTriggerArea : MonoBehaviour
{
    [SerializeField] private SteamVR_LaserPointer laserPointer;

    private void OnTriggerEnter(Collider other)
    {
        laserPointer.gameObject.GetComponent<SteamVR_LaserPointer>().enabled = true;
        laserPointer.gameObject.GetComponent<SteamVR_LaserPointer>().holder.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        laserPointer.gameObject.GetComponent<SteamVR_LaserPointer>().holder.SetActive(false);
        laserPointer.gameObject.GetComponent<SteamVR_LaserPointer>().enabled = false;
    }
}
