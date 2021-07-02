using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAnimation : MonoBehaviour
{

    private Animation anim;
    public ParticleSystem thisParticle;
    public ParticleSystem attachment;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.Play("knifeAttack_1");
            thisParticle.Play();
            attachment.Play();
        }
    }
}