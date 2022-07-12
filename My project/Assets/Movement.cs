 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpheight = 3f;


    public Transform groundcheck;
    public float grounddistance = 0.4f;
    public LayerMask groundMask;
    bool isgrounded;

    public Transform wallcheck;
    public float walldistance = 1f;
    public LayerMask wallMask;
    bool iswall;


    Vector3 velocity;
    // Update is called once per frame
    void Update()
    {
        iswall = Physics.CheckSphere(wallcheck.position, walldistance, wallMask);

        if (iswall && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(3f * -2 * gravity);
        }

        isgrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundMask);

        if(isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(3f * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
