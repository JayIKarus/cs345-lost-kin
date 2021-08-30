using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    public static int playerHealth;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        heart1 = GameObject.Find("Health_1");
        heart2 = GameObject.Find("Health_2");
        heart3 = GameObject.Find("Health_3");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        heart1 = GameObject.Find("Health_1");
        heart2 = GameObject.Find("Health_2");
        heart3 = GameObject.Find("Health_3");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            HealthManager.HurtPlayer(damageToGive, heart1, heart2, heart3);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider == target.GetComponent<Collider2D>())
        {
            HealthManager.HurtPlayer(damageToGive, heart1, heart2, heart3);
        }
    }
}