using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps: MonoBehaviour
{
    public int health = 100; //PLayer health
    private GameObject healthPowerUp;
    private GameObject speedPowerUp;
    private PlayerMovement tempSpeed;
    private bool hasSpeedPowerup = false;


    // Start is called before the first frame update
    void Start()
    {
        healthPowerUp = GameObject.Find("PowerUpContainerWhite"); //Find health power up object
       speedPowerUp = GameObject.Find("PowerUpContainerElectricSpark"); // FInd speed power up
        tempSpeed  = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //If speed power up has been enabled increase speed
        if (hasSpeedPowerup) {
            tempSpeed.playerSpeed = 30f;
        }
        else{
            //set back to normal after coundown
            tempSpeed.playerSpeed = 10f;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "health")
        {  
            //If player collides with health power -> Delelte power up and boost player health
       //     health += 100;
       //     Debug.Log(health);
        //    Destroy(healthPowerUp);
        }
        else if(other.gameObject.tag == "Speed")
        {
          //  hasSpeedPowerup = true;
          //  Destroy(speedPowerUp);
          //  StartCoroutine(SpeedPowerupCountdown());
        } 
           
    }

    IEnumerator SpeedPowerupCountdown() {
        yield return new WaitForSeconds(30);
        hasSpeedPowerup = false;
       
    }
}
