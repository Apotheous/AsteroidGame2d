using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float startPosY, spriteHeight;
    public GameObject cam;
    public float parallaxEffectY;
    public float distanceY;

    void Start()
    {
        startPosY = transform.position.y;
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
         distanceY = Vector3.Distance(cam.transform.position, transform.position); ;

        if (distanceY > spriteHeight && distanceY !> spriteHeight * 2f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + spriteHeight * 3f, transform.position.z);
        }
    }  
}
