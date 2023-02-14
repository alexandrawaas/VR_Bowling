using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
       animator = GetComponent<Animator>();
    }
    public void TurnOnCheering()
    {
        animator.enabled = false;
        animator.SetTrigger("CheeringSwitch");
        animator.enabled = true;
    }
    
    public void TurnOffCheering()
    {
        animator.SetTrigger("NoCheering");
    }
}
