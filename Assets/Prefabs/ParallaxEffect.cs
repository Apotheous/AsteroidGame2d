using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float startPosY, spriteHeight;
    public GameObject ship;
    public float distanceY;
    public float dif=3f;

    void Start()
    {
        startPosY = transform.position.y;
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        distanceY = Vector3.Distance(ship.transform.position, transform.position);

        if (distanceY > spriteHeight + 5f && distanceY > spriteHeight * 2f - 5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + spriteHeight * dif, transform.position.z);
        }
    }  
}
