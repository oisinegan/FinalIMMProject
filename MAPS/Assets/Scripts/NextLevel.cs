using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public TextMeshProUGUI info;
    void Start() {}
    void Update(){}
    //This script is attach to door in each level
    private void OnTriggerEnter(Collider other)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (other.CompareTag("Player"))
        {
            if (currentScene.Equals("map_forest"))
            {
                if (GameManager.points > 2999 && PlayerMovement.tokenCount > 3)
                {
                    SceneManager.LoadScene("CompletedMenu");
                    Cursor.lockState = CursorLockMode.None;
                    GameManager.isGameActive = false;
                }
                else
                {
                    info.gameObject.SetActive(true);
                    info.SetText("Insufficent Tokens/Points: " + PlayerMovement.tokenCount + "/4, "+ GameManager.points + "/3000");
                    StartCoroutine(labelDisplayTime());
                }
            }
            else if (currentScene.Equals("map2"))
            {
                if (PlayerMovement.tokenCount > 3)
                {
                    PlayerMovement.tokenCount = 0;
                    SceneManager.LoadScene("map_forest");
                }
                else
                {
                    info.gameObject.SetActive(true);
                    info.SetText("Insufficent tokens: " + PlayerMovement.tokenCount + "/4");
                    StartCoroutine(labelDisplayTime());
                }
            }
            else
            {
                if (GameManager.points > 999)
                {
                    SceneManager.LoadScene("map2");
                }
                else
                {
                    info.gameObject.SetActive(true);
                    info.SetText("Insufficent points: " + GameManager.points + "/1000");
                    StartCoroutine(labelDisplayTime());
                }
            }
        }
    }
    private IEnumerator labelDisplayTime()
    {
        yield return new WaitForSeconds(5);
        info.gameObject.SetActive(false);
    }
}

