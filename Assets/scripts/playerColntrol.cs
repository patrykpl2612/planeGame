using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerColntrol : MonoBehaviour
{
    public Animator animator;
    public GameObject player;

    public GameObject damageSpot1;
    public GameObject damageSpot2;
    public GameObject damageSpot3;

    public int playerLevel;
    public int health;
    

    public GameObject deathAnim;

    public float maxHealth;
    

    public Joystick joystick;

    public float speed = 4f;

    public GameObject hpBar;
    

    //float horizontalMove = 0f;
    //float verticalMove = 0f;


    public float turn;

    public Camera playerCamera;

    void Start()
    {
        playerCamera.GetComponent<Camera>().orthographicSize = 15;
        
    }

    public void TakeDamage(int damage)
    {

        health -= damage;

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Airport airport = hitInfo.GetComponent<Airport>();
        if (airport != null)
        {

            //transform.position = hitInfo.GetComponent<Airport>().airportSpawner.transform.position;
            //float t += Time.deltaTime / timeToReachTarget;
            
            //transform.position = Vector3.Lerp(test1.position, test2.position, Time.deltaTime * 0.1f);
            //speed = 0f;
            //turn = 0f;
            airport.EnterAirport();
            player.GetComponent<Weapon>().shootingAllowed = false;
            //Time.timescale = 0;
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (joystick.Horizontal != 0)
        {
            Vector3 lookVec = new Vector3(joystick.Horizontal, joystick.Vertical, 4096);
            Quaternion targetRotation = Quaternion.LookRotation(lookVec, Vector3.back);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turn);
        }

        transform.position += transform.up * Time.deltaTime * speed;

        if (health > 75)
        {
            damageSpot1.SetActive(false);
            damageSpot2.SetActive(false);
            damageSpot3.SetActive(false);
        }

        if (health <= 75 && health > 50)
        {
            damageSpot1.SetActive(true);
            damageSpot2.SetActive(false);
            damageSpot3.SetActive(false);
        }

        else if (health <= 50 && health > 25)
        {
            damageSpot1.SetActive(true);
            damageSpot2.SetActive(true);
            damageSpot3.SetActive(false);
        }

        else if (health <= 25)
        {
            damageSpot1.SetActive(true);
            damageSpot2.SetActive(true);
            damageSpot3.SetActive(true);
        }

        else if (health <= 0)
        {
            Die();
            Instantiate(deathAnim, transform.position, transform.rotation);
        }

        hpBar.transform.localScale = new Vector3(health / maxHealth, 1, 1);

    }
}
