using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}
    public void LoadFirstMap()
    {
        GameManager.points = 0;
        GameManager.isGameActive = true;
        SceneManager.LoadScene("map");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void OpenCodeRepo()
    {
        Application.OpenURL("https://github.com/oisinegan/IMM_FinalProject");
    }


}
