using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkAnimation : MonoBehaviour
{

    private Animation anim;
    public ParticleSystem thisParticle;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    anim.Play("forkStab");
        //    thisParticle.Play();
        //}
    }
}