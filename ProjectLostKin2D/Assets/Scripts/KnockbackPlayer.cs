using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackPlayer : MonoBehaviour
{
    public GameObject target;
    public Rigidbody2D rb2d;
    public float knockForce;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        rb2d = target.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name =="Player")
        {
            var player = other.GetComponent<PlayerMovement>();
            player.knockbackCount = player.knockbackLen;

            if(other.transform.position.x < transform.position.x)
            {
                player.knockFromRight = true;
                rb2d.AddForce(new Vector2(-knockForce, knockForce));
            }

            else
            {
                player.knockFromRight = false;
                rb2d.AddForce(new Vector2(knockForce, knockForce));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider == target.GetComponent<Collider2D>())
        {
            var player = target.GetComponent<PlayerMovement>();
            player.knockbackCount = player.knockbackLen;

            if (other.transform.position.x < transform.position.x)
            {
                player.knockFromRight = true;
                rb2d.AddForce(new Vector2(-knockForce, knockForce));
            }

            else
            {
                player.knockFromRight = false;
                rb2d.AddForce(new Vector2(knockForce, knockForce));
            }
        }
    }
}
