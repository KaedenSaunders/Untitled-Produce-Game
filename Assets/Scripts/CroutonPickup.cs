using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CroutonPickup : MonoBehaviour
{
    private LayerMask CroutonMask;
    private float PhysicsSphereRadius = .35f;
    // Start is called before the first frame update
    void Start()
    {
        CroutonMask = 1 << 6;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, PhysicsSphereRadius, CroutonMask);
        foreach (var hitCollider in colliders)
        {
            Debug.Log(hitCollider.transform.position);
        }
    }
}
