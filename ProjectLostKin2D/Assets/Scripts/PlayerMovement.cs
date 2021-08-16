using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horiMovement = 0f;
    bool jump = false;
    private void Update()
    {
        horiMovement = Input.GetAxisRaw("Horizontal") * runSpeed;   
    
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horiMovement * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}
