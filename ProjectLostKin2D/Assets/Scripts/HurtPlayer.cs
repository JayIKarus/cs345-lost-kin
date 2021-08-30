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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        heart1 = GameObject.Find("HeartContainer_1");
        heart2 = GameObject.Find("HeartContainer_2");
        heart3 = GameObject.Find("HeartContainer_3");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            HealthManager.HurtPlayer(damageToGive, heart1, heart2, heart3);
        }
    }

}
