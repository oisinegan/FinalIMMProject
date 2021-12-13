using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{
    private Rigidbody playerRb;
    public float playerSpeed = 15f;
    Vector3 movement;
    private bool isPlayerMoving = false;
    public int health = 200;
    public bool hasSpeedPowerup = false;
    public bool hasHealthPowerup = false;
    public GameManager gameManager;
    public static int tokenCount = 0;
   
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true; 
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Movement());
        
        //If speed power up has been enabled increase speed
        if (hasSpeedPowerup)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene.Equals("map2"))
            {
                playerSpeed = 18f;
            }
            else
            {
                playerSpeed = 30f;
            }
        }
        else
        {
            playerSpeed = 15f;
        }
        //If health power up = active player -> immortal for 30 seconds
        if (hasHealthPowerup)
        {
            if (health < 200)
            {
                health = 200;
            }
        }
        else
        {
             if (health < 1)
            { 
                health = 0;
                GameManager.isGameActive = false;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("RestartMenu");
            }
         }
    }

    //Using fixedUpdate over update, its more suited to physics and makes movement smooth
    private void FixedUpdate()
    {
        //Stop player when key released (Prevents sliding)
        if (isPlayerMoving)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene.Equals("map_forest"))
            {
                //Normalized stops increased speed when moving in direcrions -> NE,SW etc
                playerRb.AddForce(movement.normalized * playerSpeed * 5f, ForceMode.Acceleration);
            }
            else
            {
                //Normalized stops increased speed when moving in direcrions -> NE,SW etc
                playerRb.AddForce(movement.normalized * playerSpeed * 3.5f, ForceMode.Acceleration);
            }
        }
        else
        {
            playerRb.velocity = Vector3.zero;
        }
        //Stop Player from floating up when looking up and moving
        if (playerRb.position.y > 3.6f)
        {
            transform.position = new Vector3(transform.position.x, 3.6f, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Health"))
        {
            hasHealthPowerup = true;
            Destroy(other.transform.parent.gameObject);
            StartCoroutine(healthPowerupCountdown());
        }
         else if (other.CompareTag("Speed"))
         {
             hasSpeedPowerup = true;
             Destroy(other.transform.parent.gameObject);
             StartCoroutine(SpeedPowerupCountdown());
         }
        else if(other.CompareTag("Token"))
        {
            tokenCount= tokenCount+ 1;
            Destroy(other.transform.parent.gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            health= health - 25;
        }
    }

    IEnumerator Movement()
    {
        while (GameManager.isGameActive) {
            //Check if player is moving
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                isPlayerMoving = true;
            }
            else
            {
                isPlayerMoving = false;
            }

            //get input for horizontal and vertical movement
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");

            //Move player according to direction player is facing
            movement = Camera.main.transform.right * horizontalInput + Camera.main.transform.forward * verticalInput;
            yield return null;
       }
    }

    IEnumerator SpeedPowerupCountdown()
    {
        yield return new WaitForSeconds(30);
        hasSpeedPowerup = false;
    }
    IEnumerator healthPowerupCountdown()
    {
        yield return new WaitForSeconds(20);
        hasHealthPowerup = false;
    }
}