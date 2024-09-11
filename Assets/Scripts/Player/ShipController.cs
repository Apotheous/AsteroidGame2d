using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShipController : MonoBehaviour,IDamageable
{
    [System.Serializable]
    public class MyWeapon
    {
        public Transform myBarrel;
        public GameObject myAmmo;
        public int fireForce;

        public float fireTimer;
        public float fireTimerMax;

        public bool isFiring;
    }

    public MyWeapon myWeapon;

    public float MaxHealth;
    public float CurrentHealth;

    public Image healthBar;

    public Rigidbody2D shipRb;

    public float moveSpeed;

    public Vector2 moveDirection = Vector2.zero;

    [Header("Inputs")]
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;


    void Start()
    {
        myWeapon.isFiring = false;
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();

        ShipFiring();
    }

    private void GetInputs()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");

        myWeapon.isFiring = Input.GetKey(KeyCode.Space);

        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
    }

    private void FixedUpdate()
    {
        if (shipRb.transform.position.x > 8f)
        {
            moveDirection.x = Mathf.Clamp(horizontalInput, -1, 0);
        }
        else if (shipRb.transform.position.x < -8f)
        {
            moveDirection.x = Mathf.Clamp(horizontalInput, 0, 1);
        }
        shipRb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
 

    }

    private void ShipFiring()
    {
        if (myWeapon.isFiring)
        {
            myWeapon.fireTimer += Time.deltaTime;
            if (myWeapon.fireTimer >= myWeapon.fireTimerMax)
            {
                Debug.Log("Ship Firing");
              
                GameObject ammo = Instantiate(myWeapon.myAmmo,myWeapon.myBarrel);   
                Rigidbody2D ammorb = ammo.GetComponent<Rigidbody2D>();
                ammorb.AddForce(-transform.up* myWeapon.fireForce);
                myWeapon.fireTimer = 0;
            }
        }
        else 
        {
            myWeapon.fireTimer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Asteroid>() != null)
        {
            IDamage(collision.transform.GetComponent<Asteroid>().damage);
        }
        if (collision.transform.tag=="Bullet")
        {
            IDamage(collision.transform.GetComponent<BulletDestroy>().MyDamage);
        }
        
    }

    public void IDie()
    {
        Destroy(gameObject);
        Time.timeScale = 0f;
    }
    public void IDamage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        healthBar.fillAmount = CurrentHealth / MaxHealth;
        if (CurrentHealth <= 0)
        {
            IDie();
        }
    }
}
