using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BowlCrack : MonoBehaviour
{
    public UnityEvent onCrack;

    public float speedToHurtCrack = .10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Throwable" && other.GetComponent<Rigidbody>().velocity.magnitude >= speedToHurtCrack)
        {
            print("Attempting to crack the bowl.");
            onCrack.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
