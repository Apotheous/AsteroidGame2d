using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyShipOne : EnemyShipBase,IMoveable,IDamageable
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


    public float MoveSpeed = 5f; // Hareket hýzý
    public float maxX = 5f;      // Sað sýnýr
    public float minX = -5f;
    public Vector2 moveDirection = Vector2.zero;
    public Vector2 targetDirection = Vector2.zero;
    public float targetDistance;

    public GameObject target;

    private void Start()
    {
        myWeapon.isFiring = false;
        CurrentHealth = MaxHealth;
        target = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        IMoveable(MoveSpeed);
        
        TargetCheck();
    }
    public void TargetCheck()
    {
        targetDistance = Vector3.Distance(target.transform.position, transform.position);
        if (targetDistance<10f)
        {
            myWeapon.isFiring = true;
            TargetDirection();
            ShipFiring();
        }
        else { myWeapon.isFiring = false; }
    }
    public void TargetDirection()
    {
        targetDirection = target.transform.position - myWeapon.myBarrel.transform.position;
    }
    private void ShipFiring()
    {
        if (myWeapon.isFiring)
        {
            myWeapon.fireTimer += Time.deltaTime;
            if (myWeapon.fireTimer >= myWeapon.fireTimerMax)
            {
                Debug.Log("Ship Firing");

                GameObject ammo = Instantiate(myWeapon.myAmmo, myWeapon.myBarrel);
                ammo.transform.SetParent(null);
                ammo.transform.rotation = Quaternion.LookRotation(Vector3.forward, targetDirection);
                Rigidbody2D ammorb = ammo.GetComponent<Rigidbody2D>();
                ammorb.AddForce(targetDirection * myWeapon.fireForce);
                myWeapon.fireTimer = 0;
            }
        }
        else
        {
            myWeapon.fireTimer = 0;
        }
    }
    public void IMoveable(float moveSpeed)
    {

        // X pozisyonunu kontrol et, eðer sýnýrlarý aþarsa yönü tersine çevir
        if (transform.position.x >= maxX)
        {
            if (moveSpeed>0)
            {
                MoveSpeed = moveSpeed*-1f;
            }
            // Hýzý tersine çevir
        }
        else if (transform.position.x <= minX)
        {
            if (moveSpeed < 0)
            {
                MoveSpeed = moveSpeed * -1f;
            }
        }

        // Nesneyi hareket ettir (saða veya sola)
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            IDamage(collision.transform.GetComponent<BulletDestroy>().MyDamage);
        }
    }

    public void IDie()
    {
        Destroy(gameObject);
        GameManager.instance.scoreVal += 500;
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
