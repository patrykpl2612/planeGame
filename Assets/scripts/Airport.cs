using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airport : MonoBehaviour
{

    public Camera playerCamera;
    public playerColntrol player;

    public GameObject airportSpawner;
    public GameObject airportParking;
    public SpriteRenderer arrowSign;

    public Transform playerTransform;

    public GameObject disableJoystick;
    public GameObject disableShootButton;
    public GameObject exitAirportButton;
    public Transform airportStartPoint;

    private float tempSpeed;
    private float tempTurn;

    public float regenerationRate = 1f;
    private float nextRegen = 0.0f;

    private bool regenerating = false;

    void Start()
    {
        //exitAirportButton.GetComponent<Button>();
        //exitAirportButton.onClick.AddListener(exitAirport);


    }

    public void EnterAirport()
    {
        tempSpeed = player.GetComponent<playerColntrol>().speed;
        player.GetComponent<playerColntrol>().speed = 0;
        tempTurn = player.GetComponent<playerColntrol>().turn;
        player.GetComponent<playerColntrol>().turn = 0;

        playerCamera.transform.localScale = new Vector3(0.33f, 0.33f, 1);

        arrowSign.enabled = false;

        //Vector3 newPosition = Vector3.Lerp(playerTransform.position, airportParking.transform.position, Time.deltaTime * 5);
        playerTransform.position = airportParking.transform.position;
        playerTransform.transform.eulerAngles = new Vector3(45, 0, -45);

        playerCamera.orthographicSize = 5;

        playerTransform.transform.localScale = new Vector3(0.5f, 0.5f, 1);

        disableJoystick.SetActive(false);
        disableShootButton.SetActive(false);
        exitAirportButton.SetActive(true);

        regenerating = true;

        //player.GetComponent<playerColntrol>().SetActive(false);
    }

    void Update()
    {
        if (Time.time > nextRegen && regenerating && player.GetComponent<playerColntrol>().health < player.GetComponent<playerColntrol>().maxHealth)
        {
            nextRegen = Time.time + regenerationRate;
            player.GetComponent<playerColntrol>().health += 5;
        }
    }

    public void exitAirport()
    {
        playerTransform.position = airportStartPoint.position;
        playerTransform.transform.eulerAngles = new Vector3(0, 0, 0);

        playerCamera.orthographicSize = 15;

        playerTransform.transform.localScale = new Vector3(1, 1, 1);

        disableJoystick.SetActive(true);
        disableShootButton.SetActive(true);
        exitAirportButton.SetActive(false);

        playerCamera.transform.localScale = new Vector3(1, 1, 1);


        regenerating = false;
        //Debug.Log(tempSpeed);
        //Debug.Log(tempTurn);

        player.GetComponent<playerColntrol>().speed = tempSpeed;
        player.GetComponent<playerColntrol>().turn = tempTurn;
        player.GetComponent<Weapon>().shootingAllowed = true;
        arrowSign.enabled = true;
    }

}
