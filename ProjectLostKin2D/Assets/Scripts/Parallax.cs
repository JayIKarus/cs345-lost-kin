using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startPosX, startPosY;
    private float distanceX, distanceY;
    private float tempX, tempY;

    public bool ParallaxYLayer;
    [SerializeField] private GameObject camera;
    [SerializeField] private float parallaxEffect;
    
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    
    void Update()
    {
        xAxisParallax();
        if (ParallaxYLayer) {
            yAxisParallax();
        }
        transform.position = new Vector3(startPosX + distanceX, startPosY + distanceY, transform.position.z);
    }

    void xAxisParallax()
    {
        tempX = (camera.transform.position.x * (1 - parallaxEffect));
        distanceX = (camera.transform.position.x * parallaxEffect);

        if (tempX > startPosX + length)
        {
            startPosX += length;
        }
        else if(tempX < startPosX - length)
        {
            startPosX -= length;
        }
    }

    void yAxisParallax()
    {
        tempY = (camera.transform.position.y * (1 - parallaxEffect));
        distanceY = (camera.transform.position.y * parallaxEffect);

        if (tempY > startPosY + length)
        {
            startPosY += length;
        }
        else if(tempY < startPosY - length)
        {
            startPosY -= length;
        }
    }
}
