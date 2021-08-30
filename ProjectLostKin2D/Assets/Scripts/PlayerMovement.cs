using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public Animator p_animator;
    public float runSpeed = 10f;
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public int defaultAdditionalJumps = 1;

    public int additionalJumps;
    public float rememberGroundedFor;
    public float lastTimeGrounded;

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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            p_animator.SetTrigger("Walk_Right");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            p_animator.SetTrigger("Walk_Left");
        }
        else
        {
            p_animator.ResetTrigger("Idle");
        }
        Move();
        Jump();
        BetterJump();
        CheckIfGrounded();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * runSpeed;
        body.velocity = new Vector2(moveBy, body.velocity.y);

        if (knockbackCount <= 0)
        {
            body.velocity = new Vector2(moveBy, body.velocity.y);
        }
        else
        {
            if(knockFromRight)
            {
                body.velocity = new Vector2(-knockback, knockback);
            }
            if(!knockFromRight)
            {
                body.velocity = new Vector2(knockback, knockback);
            }
            knockbackCount -= Time.deltaTime;
        }

    }

    void Jump()
    {
        if (((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow))) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0))
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            additionalJumps--;

        }
    }

    void BetterJump()
    {
        if (body.velocity.y < 0)
        {
            body.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (body.velocity.y > 0 && (!Input.GetKey(KeyCode.Space) || !Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.UpArrow)))
        {
            body.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundChecker.position, checkGroundRadius, groundLayer);

        if (collider != null)
        {
            isGrounded = true;
            additionalJumps = defaultAdditionalJumps;
        }
        else
        {
            if(isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }


}
