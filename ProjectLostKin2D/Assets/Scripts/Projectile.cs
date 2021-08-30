using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    public Rigidbody2D rb2d;
    public GameObject target;
    public Vector2 moveDirection;
    public Animator pAnimator;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pAnimator = gameObject.GetComponent<Animator>();
        target = GameObject.Find("Player");
        moveDirection = (target.transform.position - transform.position).normalized * projectileSpeed;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.gameObject.layer == 6)
        {
            Debug.Log("Hit!");
            pAnimator.SetTrigger("hitConfirm");
            Destroy(gameObject);
        }
    }
}
