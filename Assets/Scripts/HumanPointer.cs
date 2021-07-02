using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanPointer : MonoBehaviour
{
    public Camera cam;
    private Animation anim;
    private Vector3 direction;
    public ParticleSystem thisParticle;
    public AudioSource hitnoise;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * .02f;
    }

    public void MouseMoved(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        direction = new Vector3(-movement.x, 0, -movement.y);
    }

    public void FallDown()
    {
        anim.Play("forkStab");
        thisParticle.Play();
        hitnoise.Play();
    }
}
