using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationActivation : MonoBehaviour
{

    public Animation anim;
    public ParticleSystem thisParticle;

    void Start()
    {
        //anim = GetComponent<Animation>();
    }


    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        anim.Play("pepperShakeAnim");
    //        thisParticle.Play();
    //    }
    //}

    public void PlayAnim()
    {
        anim.Play("pepperShakeAnim");
        thisParticle.Play();
    }
}
