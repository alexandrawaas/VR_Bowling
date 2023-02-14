using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonAnimator : MonoBehaviour
{
    [SerializeField] private List<Person> persons;

    public void MakePeopleCheer()
    {
        foreach (Person person in persons)
        {
            person.TurnOnCheering();
        }
    }
    
    public void StopPeopleCheer()
    {
        foreach (Person person in persons)
        {
            person.TurnOffCheering();
        }
    }
}
