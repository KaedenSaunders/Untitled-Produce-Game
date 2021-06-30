//made by sam k

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPointerPlayerOne : MonoBehaviour
{

    //this script is diffrent from HumanPointedOkayerTwo only by the controls. everyhting else is the same. if you have a diffrent control scheme feel free to change it

    public Rigidbody rb;
    public float speed;
    public bool playerOne;

    public HumanObjectController HOController;

    private void OnTriggerStay(Collider other)
    {
        if ((Input.GetKey(KeyCode.Mouse1)) && other.tag == "Knife") 
        {
            HOController.KnifeSelect(playerOne); //calls function in human object controller
        }
        if ((Input.GetKey(KeyCode.Mouse1)) && other.tag == "Fork") //uses z to pick up and x to attack since using one button was making you pick up and attack immediately
        {
            HOController.ForkSelect(playerOne);
        }
        if ((Input.GetKey(KeyCode.Mouse1)) && other.tag == "Pepper")
        {
            HOController.PepperSelect(playerOne);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //calls all attack fuctions in the human object controller
        {
            print("attack");
            rb.velocity = Vector3.zero;
            HOController.KnifeAttack(playerOne);
            HOController.ForkAttack(playerOne);
            HOController.PepperAttack(playerOne);
        }


        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            rb.AddForce (Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.forward * speed * Time.deltaTime);
        }

        if ((Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.UpArrow))){}
        else
        {
            rb.velocity = Vector3.zero; //stops controller to prevent sliding all around the place
        }


    }

}
