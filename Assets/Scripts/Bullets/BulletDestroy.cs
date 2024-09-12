using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public float MyDamage;
    public float lifetime = 5f; 
    private float lifeTimer;

    private void OnEnable()
    {
        lifeTimer = lifetime;
    }
    private void Update()
    {
        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0f)
        {
            Destroy(this.gameObject);
            Debug.Log("Bullet Destroy Edildi");
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
