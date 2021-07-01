using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarrotMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    private Vector3 nudge;
    private Vector3 lookDir;

    private static Vector3 ray1;
    private static Vector3 ray2;
    private static Vector3 ray3;

    private static Vector3 origin;

    private LayerMask layerMask = 1 << 2;

    private bool groundedPlayer;

    private float playerSpeed = 1.5f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        float alpha = 2 * Mathf.PI / 3;
        float beta = -Mathf.PI / 4;
        float x = Mathf.Cos(alpha) * Mathf.Cos(beta);
        float z = Mathf.Sin(alpha) * Mathf.Cos(beta);
        float y = Mathf.Sin(beta);

        layerMask = ~layerMask;
        origin = transform.position;
        ray1 = new Vector3(1, -1, 0);
        ray2 = new Vector3(x, y, z);
        ray3 = new Vector3(x, y, -z);
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.y += gravityValue * Time.deltaTime;

        //groundedPlayer = controller.isGrounded;
        //if (groundedPlayer && direction.y < 0)
        //{
        //    direction.y = 0f;
        //}

        // this function is now used only to find the nudge vector
        findNormal();

        transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        controller.Move((nudge + direction) * playerSpeed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        direction = new Vector3(-movement.x, 0, -movement.y);
    }


    // this function both finds the normal and it gives a nudge value so the
    // characters stay inside the bowl
    public Vector3 findNormal()
    {
        origin = transform.position;
        Vector3 normal = Vector3.zero;

        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;

        bool didhit1 = false;
        bool didhit2 = false;
        bool didhit3 = false;

        if (Physics.Raycast(origin, ray1, out hit1, 2, layerMask))
            didhit1 = true;

        if (Physics.Raycast(origin, ray2, out hit2, 2, layerMask))
            didhit2 = true;

        if (Physics.Raycast(origin, ray3, out hit3, 2, layerMask))
            didhit3 = true;

        if (didhit1 && didhit2 && didhit3)
        {
            Debug.DrawRay(origin, ray1.normalized * hit1.distance, Color.yellow);
            Debug.DrawRay(origin, ray2.normalized * hit2.distance, Color.red);
            Debug.DrawRay(origin, ray3.normalized * hit3.distance, Color.blue);

            // nudge calculation
            nudge = Vector3.zero;
            if (hit1.distance >= 0.25f || hit2.distance >= 0.25f || hit3.distance >= 0.25f)
            {
                nudge = ray1.normalized * hit1.distance * 2 + ray2.normalized * hit2.distance * 2 + ray3.normalized * hit3.distance * 2;
            }

            Plane plane = new Plane(hit1.point, hit2.point, hit3.point);
            normal = -plane.normal;

            //Debug.DrawRay(origin, normal, Color.green);
        }

        

        return normal;
    }
}
