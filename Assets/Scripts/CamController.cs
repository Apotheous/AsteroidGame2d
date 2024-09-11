using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform cam;
    public Transform player;
    public float dist;
    void Start()
    {
        cam.transform.position = new Vector3(0,player.position.y+dist,0);
    }

    void Update()
    {
        cam.transform.position = new Vector3(0, player.position.y + dist, -10);
    }
}
