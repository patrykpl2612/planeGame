using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;

    public GameObject damageSpot1;
    public GameObject damageSpot2;
    public GameObject damageSpot3;


    private float fireRate = 0.2f;
    private float nextFire = 0.0f;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public GameObject player;

    public GameObject deathAnim;

    public float rotate;

    public void TakeDamage(int damage)
    {

        health -= damage;
        
        if (health <= 75)
        {
            damageSpot1.SetActive(true);
        }

        if (health <= 50)
        {
            damageSpot2.SetActive(true);
        }

        if (health <= 25)
        {
            damageSpot3.SetActive(true);
        }

        if (health <= 0)
        {
            Die();
            Instantiate(deathAnim, transform.position, transform.rotation);
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextFire && player.GetComponent<Weapon>().shootingAllowed)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

        //Vector3 lookVec = new Vector3(Random.value % 360, Random.value % 360, 4096);
        //Quaternion targetRotation = Quaternion.LookRotation(lookVec, Vector3.back);
        transform.Rotate(0f, 0f, rotate);

        transform.position += transform.up * Time.deltaTime * 2;
    }
}
