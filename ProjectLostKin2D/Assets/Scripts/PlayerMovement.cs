using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Rigidbody2D body;
    
    public float knockback;
    public float knockbackCount;
    public float knockbackLen;
    public bool knockFromRight;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ///p_animator = gameObject.GetComponent<Animator>();
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
        /*if (knockbackCount <= 0)
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

        controller.Move(horiMovement * Time.fixedDeltaTime, false, jump);
        jump = false;
    }


}
