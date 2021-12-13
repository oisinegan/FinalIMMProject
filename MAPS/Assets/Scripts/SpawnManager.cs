using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject healthPowerup;
    public GameObject speedPowerup;
    public GameObject token;
    public int enemyCount;
    public int waveNumber;
    private bool roundStart = false;

  
    void Start(){ }

    // Update is called once per frame
    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0 && GameManager.isGameActive)
        {
            StartCoroutine(inbetweenRoundTime());
            if (roundStart == true)
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
                if (waveNumber % 3 == 0)
                {
                    if (currentScene.Equals("map2"))
                    {
                        Instantiate(speedPowerup, new Vector3(32, 4, -19), speedPowerup.transform.rotation);
                    }
                    else
                    {
                        Instantiate(speedPowerup, GenerateSpawnPosition() + new Vector3(0, 2, 0), speedPowerup.transform.rotation);
                    }
                }
                if (waveNumber % 4 == 0 && GameManager.isGameActive)
                {
                    if (currentScene.Equals("map2"))
                    {
                        Instantiate(healthPowerup, new Vector3(26, 4, -19), healthPowerup.transform.rotation);
                    }
                    else
                    {
                        Instantiate(healthPowerup, GenerateSpawnPosition() + new Vector3(0, 2, 0), healthPowerup.transform.rotation);
                    }
                }
                
            }
          
        }
        if (enemyCount > 0)
        {
            roundStart = false;
        }
    }

    void SpawnEnemyWave(int enemy)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene.Equals("map2"))
        {
            enemy += 2;
            for (int i = 0; i < enemy; i++)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition() + new Vector3(0, 0.5f, 0), enemyPrefab.transform.rotation);
            }
        }
        else if(currentScene.Equals("map_forest"))
        {
            enemy *= 2;
            for (int i = 0; i < enemy; i++)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            }
        }
        else {
            for (int i = 0; i < enemy; i++)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            }
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float randomArea = Random.Range(1, 5);
        float spawnPositionX;
        float spawnPositionZ;
        string currentScene = SceneManager.GetActiveScene().name;
       if (currentScene.Equals("map")) {
            if (randomArea == 1)
            {
                spawnPositionX = Random.Range(2, 4);
                spawnPositionZ = Random.Range(-9, -19);
            }
            else if (randomArea == 2)
            {
                spawnPositionX = Random.Range(15, 17);
                spawnPositionZ = Random.Range(-9, -19);
            }
            else if (randomArea == 3)
            {
                spawnPositionX = Random.Range(4, 17);
                spawnPositionZ = Random.Range(-21, -36);
            }
            else
            {
                spawnPositionX = Random.Range(1, 25);
                spawnPositionZ = Random.Range(-61, -69);
            }
        }
        else if (currentScene.Equals("map2")) {
            if (randomArea == 1)
            {
                spawnPositionX = Random.Range(9, 25);
                spawnPositionZ = Random.Range(-4, -30);
            }
            else if (randomArea == 2)
            {
                spawnPositionX = Random.Range(45, 48);
                spawnPositionZ = Random.Range(-4, -30);
                
            }
            else if (randomArea == 3)
            {
                spawnPositionX = Random.Range(35, 42);
                spawnPositionZ = -6;

            }
            else
            {
                spawnPositionX = Random.Range(32, 38);
                spawnPositionZ = Random.Range(-23, -27);
            }
        }
        else
        {
            if (randomArea == 1 || randomArea == 2)
            {
                spawnPositionX = Random.Range(50, 93);
                spawnPositionZ = Random.Range(4, 118);
               
            }
            else if (randomArea == 4 || randomArea == 5)
            {
                spawnPositionX = Random.Range(3, 34);
                spawnPositionZ = Random.Range(4, 118);
            }
            else
            {
                spawnPositionX = Random.Range(5, 100);
                spawnPositionZ = Random.Range(110, 118);
            }
        }
        Vector3 randomPosition = new Vector3(spawnPositionX, 2f, spawnPositionZ);
        return randomPosition;
    }

    public IEnumerator inbetweenRoundTime()
    {
        yield return new WaitForSeconds(10);
        roundStart = true;
    }
}
