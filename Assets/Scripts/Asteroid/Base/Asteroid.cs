using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour, IDamageable, IMoveable
{
    public AsteroidType asteroidType;

    public float maxHealth;
    public float CurrentHealth;

    public float damage;
    public float MoveSpeed;

    public Image healthBar;

    private void Start()
    {
        SetAsteroidProperties(asteroidType);
        CurrentHealth = maxHealth;
        
    }
    private void FixedUpdate()
    {
        IMoveable(MoveSpeed);
    }
    public void IDamage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        healthBar.fillAmount = CurrentHealth / maxHealth;
        if (CurrentHealth <= 0)
        {
            IDie();
        }
    }

    public void IDie()
    {
        GameManager.instance.scoreVal += 50;
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Bullet")
        { 
            IDamage(20); 
        }    
    }

    private void SetAsteroidProperties(AsteroidType asteroidType)
    {
        switch (asteroidType)
        {
            case AsteroidType.LEVEL_SMALL:
                maxHealth = 50f;
                damage = 10;
                break;
            case AsteroidType.LEVEL_MID:
                maxHealth = 100f;
                damage = 30;
                break;
            case AsteroidType.LEVEL_BIG:
                maxHealth = 200f;
                damage = 50;
                break;
            default:
                break;
        }
    }

    public void IMoveable(float MoveSpeed)
    {
        transform.Translate(-transform.up * MoveSpeed * Time.deltaTime);
    }
}

public enum AsteroidType
{
    LEVEL_SMALL,
    LEVEL_MID, 
    LEVEL_BIG
}

