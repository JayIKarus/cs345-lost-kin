using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    private GameObject heart1;
    private GameObject heart2;
    private GameObject heart3;

    int deathCounter;

    private void Awake()
    {
        heart1 = GameObject.Find("HeartContainer_1");
        heart2 = GameObject.Find("HeartContainer_2");
        heart3 = GameObject.Find("HeartContainer_3");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        deathCounter += 1;

        if(deathCounter == 1)
        {
            Destroy(heart1);
        }
        if (deathCounter == 2)
        {
            Destroy(heart2);
        }
        if (deathCounter == 3)
        {
            Destroy(heart3);
        }
    }

}
