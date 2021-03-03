using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public Rigidbody2D rb;
    public int bulletDamage = 5;
    public GameObject impactEffect;

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, 1.0f);
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(bulletDamage);
        }

        playerColntrol player = hitInfo.GetComponent<playerColntrol>();
        if (player != null)
        {
            player.TakeDamage(bulletDamage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
