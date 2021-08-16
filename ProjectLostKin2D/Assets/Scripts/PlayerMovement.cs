using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public bool isSwinging = false;
    bool isGrounded = false;
    public Transform isGroundChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public float knockback;
    public float knockbackCount;
    public float knockbackLen;
    public bool knockFromRight;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        p_animator = gameObject.GetComponent<Animator>();
    }
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
