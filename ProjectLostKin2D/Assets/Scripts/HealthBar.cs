using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int health;
    public int imageNum;

    public Image[] pump;
    public Sprite filledIn;
    public Sprite notFilledIn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(health > imageNum)
        {
            health = imageNum;
        }

        for(int i = 0; i < pump.Length; i++)
        {
            if(i < health)
            {
                pump[i].sprite = filledIn;
            }
            else
            {
                pump[i].sprite = notFilledIn;
            }

            if (i < imageNum)
            {
                pump[i].enabled = true;
            }
            else
            {
                pump[i].enabled = true;
            }
        }
    }
}
