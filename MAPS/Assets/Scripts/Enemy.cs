using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    private float enemyHealth = 120f;
 

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyRb.freezeRotation = true;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameActive)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene.Equals("map"))
            {
                speed = 3;

            }
            else if (currentScene.Equals("map2"))
            {
                speed = 1.9f;
                enemyRb.position = new Vector3(enemyRb.position.x, enemyRb.position.y+10, enemyRb.position.z);
            }
            else
            {
                speed = 4.3f;
            }
            Vector3 positionn = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            transform.LookAt(player.transform);
            enemyRb.MovePosition(positionn);

            if(currentScene.Equals("map2"))
            {
                transform.localScale = new Vector3(.6f,.6f,.6f);
            }
            if (currentScene.Equals("map_forest"))
            {
                transform.localScale = new Vector3(2f, 2f, 2f);
            }

        }
    }

    //Detect when bullet hits enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            GameManager.points += 10;
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene.Equals("map"))
            {
                enemyHealth -= 60;
            }
            else if (currentScene.Equals("map2"))
            {
                enemyHealth -= 40;
            }
            else
            {
                enemyHealth -= 30;
            }
            
            if (enemyHealth <= 0)
            {
                GameManager.points += 50;
                Destroy(gameObject);
                Destroy(other);
            }
        }
    }
}
