using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour, IMoveable
{
    public float moveSpeed;
    void Update()
    {
        IMoveable(moveSpeed);

    }

    public void IMoveable(float MoveSpeed)
    {
        transform.Translate(transform.up * MoveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.transform.gameObject);
    }
}
