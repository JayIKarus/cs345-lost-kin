using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxPlayerHealth;
    public static int playerHealth;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxPlayerHealth;
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth == 2)
        {
            Destroy(heart3);
        }
        if(playerHealth == 1)
        {
            Destroy(heart2);
        }
        if(playerHealth <= 0)
        {
            Destroy(heart1);
            levelManager.RespawnPlayer();
        }
    }

    public static void HurtPlayer(int damageToGive, GameObject heart1, GameObject heart2, GameObject heart3)
    {
        playerHealth -= damageToGive;
    }

    public void FullHealth()
    {
        playerHealth = maxPlayerHealth;
    }
}
