using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            }

            else
            {
                player.knockFromRight = false;
            }
        }
    }
}
