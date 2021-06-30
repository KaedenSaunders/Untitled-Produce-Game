using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkAnimation : MonoBehaviour
{

    public Animation anim;
    public ParticleSystem thisParticle;

    void Start()
    {
        //anim = GetComponent<Animation>();
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        anim.Play("forkStab");
    //        thisParticle.Play();
    //    }
    //}

    public void PlayAnim()
    {
        anim.Play("forkStab");
        thisParticle.Play();
    }
}