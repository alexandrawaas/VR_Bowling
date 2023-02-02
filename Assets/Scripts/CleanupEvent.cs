using UnityEngine;
using Valve.VR.InteractionSystem;

public class CleanupEvent : MonoBehaviour
{
    [SerializeField] private LaneObjectDespawner despawner;
    
    public void OnPress()
    {
        Debug.Log("Cleanup Button was pressed");
        despawner.RemoveAllObjectsInTrigger();
    }
}
