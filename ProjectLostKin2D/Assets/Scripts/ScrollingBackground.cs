using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    [SerializeField] private float speed;
    private float newPos;
    Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPos = Mathf.Repeat(Time.time * speed, 1920);
        transform.position = startPos + Vector2.right * newPos;
    }
}
