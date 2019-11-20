using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoCached
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private float lookRotationSpeed = 10f;

    [SerializeField] Transform playerPivot;
    private InputManager inputJoystick;


    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        inputJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<InputManager>();
    }




    private void Update()
    {
        playerPivot.position = transform.position + Quaternion.AngleAxis(-20f, Vector3.up) * inputJoystick.charInput;

        if(playerPivot.localPosition != Vector3.zero)
        {
            MoveCharacter();
        }
    }


    private void MoveCharacter()
    {

       
        //Remember gravity component of rb
        float tmpVertVelocity = rb.velocity.y;
        //Calculate rb vector
        rb.velocity = new Vector3(playerPivot.position.x - transform.position.x, 
                                    playerPivot.position.y - transform.position.y,
                                    playerPivot.position.z - transform.position.z).normalized * playerSpeed;

        //Debug.DrawLine(transform.position, transform.position + rigidbody.velocity, Color.red);

        Vector3 dir = rb.velocity.normalized;


        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir, Vector3.up), lookRotationSpeed);
        }



        //Change back from directional(rotation) rb to proper rb with gravity
        rb.velocity = new Vector3(rb.velocity.x, tmpVertVelocity, rb.velocity.z);
    }


}
