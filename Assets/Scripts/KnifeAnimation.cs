using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAnimation : MonoBehaviour
{

    public Animation anim;
    public ParticleSystem thisParticle;
    public ParticleSystem attachment;

    void Start()
    {
        //anim = GetComponent<Animation>();
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        anim.Play("knifeAttack_1");
    //        thisParticle.Play();
    //        attachment.Play();
    //    }
    //}

    public void PlayAnim()
    {
        anim.Play("knifeAttack_1");
        thisParticle.Play();
        attachment.Play();
    }
}