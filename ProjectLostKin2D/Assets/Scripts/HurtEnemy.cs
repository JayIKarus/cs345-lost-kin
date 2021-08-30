using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    public float bounce;
    private Rigidbody2D rigbod;
    // Start is called before the first frame update
    void Start()
    {
        rigbod = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Enemy")
        {
            other.GetComponent<EnemyHealth>().giveDamage(damageToGive);
            rigbod.velocity = new Vector2(rigbod.velocity.x, bounce);
        }
    }
}
