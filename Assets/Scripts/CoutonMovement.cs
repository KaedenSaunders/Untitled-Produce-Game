using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CoutonMovement : MonoBehaviour
{
    public Vector2 movement;
    public Vector3 direction;

    public float speed = 2.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    Rigidbody controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Rigidbody>();

        //movementAction = map.actions("Move");
        //fire = map.FindAction("Fire");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        controller.velocity += direction / (Time.fixedDeltaTime * 150);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        direction = new Vector3(-movement.x, 0, -movement.y);
    }
}