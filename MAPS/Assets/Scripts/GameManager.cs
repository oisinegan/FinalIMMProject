using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public static bool isGameActive = false;
    public Button restartButton;
    public TextMeshProUGUI pointsLabel;
    public TextMeshProUGUI healthLabel;
    public static int points = 0;
    public int health;
    public TextMeshProUGUI gameInstruction;
   

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(displayIntruction());
        GameObject player = GameObject.Find("Player");
        PlayerMovement script = player.GetComponent<PlayerMovement>();
        if (isGameActive == false)
        {
            Cursor.lockState = CursorLockMode.None;
            //Fixed bug of when game ended label didn't update to zero quick enough
            if(script.health/2 < 13)
            {
                healthLabel.text = "Health: 0";
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            pointsLabel.text = "Points: " + points;
            healthLabel.text = "Health: " + script.health / 2;

            if (script.hasHealthPowerup)
            {
                healthLabel.text = "Health: Immortal";
            }
        }
    }
    public IEnumerator displayIntruction()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene.Equals("map2"))
        {
            yield return new WaitForSeconds(4.5f);
            gameInstruction.SetText("TIP: Only enter buildings between rounds or when immortal!");
            yield return new WaitForSeconds(5.5f);
            gameInstruction.gameObject.SetActive(false);
        }
        else
        {
            yield return new WaitForSeconds(5);
            gameInstruction.gameObject.SetActive(false);
        }
 
    }
}
