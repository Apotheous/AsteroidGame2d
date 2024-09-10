using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour, IDamageable
{
    public float maxHealth;
    public float CurrentHealth;
    public Image healthBar;
    private void Start()
    {
        CurrentHealth = 100;
        Debug.Log("Asteroid -+-+- CurrentHealth = " + CurrentHealth);
        Debug.Log("Asteroid -+-+- MaxHealth = " + maxHealth);
    }
    public void IDamage(float damageAmount)
    {
        Debug.Log("Asteroid -+-+- Damage = " + CurrentHealth);
        Debug.Log("Asteroid -+-+- Damage = " + maxHealth);
        CurrentHealth -= damageAmount;
        healthBar.fillAmount = CurrentHealth / maxHealth;
        if (CurrentHealth <= 0)
        {
            Debug.Log("Asteroid +-+- Damage = " + CurrentHealth);
            IDie();
        }
    }

    public void IDie()
    {
        Debug.Log("Asteroid +-+- die");
        //StateMachine.ChangeState(DieState);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamage(20);
    }
}

