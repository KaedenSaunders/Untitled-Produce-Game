using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanPointerPlayerTwo : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public bool playerOne;

    public humanObjectController HOController;

    private void OnTriggerStay(Collider other)
    {
        if ((Input.GetKey(KeyCode.N)) && other.tag == "Knife")
        {
            HOController.KnifeSelect(playerOne); //calls function in human object controller
        }
        if ((Input.GetKey(KeyCode.N)) && other.tag == "Fork") //uses z to pick up and x to attack since using one button was making you pick up and attack immediately
        {
            HOController.ForkSelect(playerOne);
        }
        if ((Input.GetKey(KeyCode.N)) && other.tag == "Pepper")
        {
            HOController.PepperSelect(playerOne);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) //calls all attack fuctions in the human object controller
        {
            rb.velocity = Vector3.zero;
            HOController.KnifeAttack(playerOne);
            HOController.ForkAttack(playerOne);
            HOController.PepperAttack(playerOne);
        }


        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.forward * speed * Time.deltaTime);
        }

        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S))) { }
        else
        {
            rb.velocity = Vector3.zero; //stops controller to prevent sliding all around the place
        }


    }

}
