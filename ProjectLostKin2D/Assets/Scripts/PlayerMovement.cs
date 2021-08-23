using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Rigidbody2D body;
    public Animator p_animator;
    
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
    bool crouch = false;
    private void Update()
    {
        horiMovement = Input.GetAxisRaw("Horizontal") * runSpeed;   
    
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButton("Crouch")) {
            p_animator.SetBool("IsCrouching", true);
            crouch = true;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            p_animator.SetBool("IsMoving", true);
            if (controller.m_FacingRight == true)
            {
                p_animator.SetBool("IsFacingRight", true);
            }
            if (crouch == false)
            {
                p_animator.SetBool("IsCrouching", false);
            }
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            p_animator.SetBool("IsMoving", true);
            if (controller.m_FacingRight == false)
            {
                p_animator.SetBool("IsFacingRight", false);
            }
            if (crouch == false)
            {
                p_animator.SetBool("IsCrouching", false);
            }
        }
        else
        {
            p_animator.SetBool("IsMoving", false);
        }
        
       
        /*
        if (knockbackCount <= 0)
        {
            body.velocity = new Vector2(0f, body.velocity.y);
        }
        else
        {
            if (knockFromRight)
            {
                body.velocity = new Vector2(-knockback, knockback);
            }
            if (!knockFromRight)
            {
                body.velocity = new Vector2(knockback, knockback);
            }
            knockbackCount -= Time.deltaTime;
        }*/
    }

    private void FixedUpdate()
    {
        
        controller.Move(horiMovement * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        crouch = false;
    }


}
