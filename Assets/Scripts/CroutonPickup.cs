using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CroutonPickup : MonoBehaviour
{
    private LayerMask CroutonMask;
    private float PhysicsSphereRadius = .35f;
    private Collider ClosestCrouton;
    private bool carrying = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        CroutonMask = 1 << 6;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestCrouton();
    }

    void FindClosestCrouton()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, PhysicsSphereRadius, CroutonMask);
        if (colliders.Length > 0)
        {
            ClosestCrouton = colliders[0];
            foreach (var hitCollider in colliders)
            {
                if (Vector3.Distance(hitCollider.transform.position, transform.position) < Vector3.Distance(ClosestCrouton.transform.position, transform.position))
                    ClosestCrouton = hitCollider;
            }
        }
        else
        {
            ClosestCrouton = null;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (carrying)
            {
                // just dropped something
                carrying = false;
                animator.SetBool("carrying", false);
                Rigidbody crouton = GetComponentInChildren<Rigidbody>();
                crouton.constraints = RigidbodyConstraints.None;
                crouton.transform.SetParent(transform.parent.parent);
                crouton.velocity = transform.forward * 3 + transform.up * 2;
            }
            else if (ClosestCrouton)
            {
                // just picked something up
                Debug.Log("Picked up");
                carrying = true;
                animator.SetBool("carrying", true);
                ClosestCrouton.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                ClosestCrouton.transform.SetParent(transform);
                ClosestCrouton.transform.position = transform.position + transform.up * 0.25f + transform.forward * 0.25f;
            }
            Debug.Log("Called");
        }
    }
}
