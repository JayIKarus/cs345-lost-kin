using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currCheckpoint;
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        player.transform.position = currCheckpoint.transform.position;
    }
}
