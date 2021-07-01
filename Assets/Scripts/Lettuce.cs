using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lettuce : MonoBehaviour
{
    public float minFallTime;
    public float maxFallTime;

    public uint numPlayersPickingUp = 1;
    public bool isBeingPickedUp = false;

    private float currentRandomTime;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentRandomTime = Random.Range(minFallTime, maxFallTime);
    }


    // Update is called once per frame
    void Update()
    {
        if (currentRandomTime <= 0)
        {
            animator.SetBool("HasFallen", true);
            if (isBeingPickedUp)
            {
                animator.SetFloat("PickingUp", 1 *  numPlayersPickingUp);
            } else
            {
                animator.SetFloat("PickingUp", -1);
            }

        }
        else
        {
            currentRandomTime -= Time.deltaTime;
        }
    }

    void OnPickedUp()
    {
        currentRandomTime = Random.Range(minFallTime, maxFallTime);
    }
}
