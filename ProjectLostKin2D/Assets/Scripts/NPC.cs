using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;
    public DialogueTrigger npcDialogue;
    public float EnemySpeed;
    public bool XMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(XMove)
        {
            transform.Translate(2 * Time.deltaTime * EnemySpeed, 0, 0);
            transform.localScale = new Vector2(2,2);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * EnemySpeed, 0, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("I'm triggered");
            npcDialogue.TriggerDialogue();
        }

        if (other.CompareTag("Turn"))
        {
            if(XMove)
            {
                XMove = false;
            }

            else
            {
                XMove = true;
            }
        }
    }
    
}
