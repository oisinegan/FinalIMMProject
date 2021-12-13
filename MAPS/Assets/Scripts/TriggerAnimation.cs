using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    Animator monsterAnim;
   
    void Start()
    {
        monsterAnim = GetComponent<Animator>();
    }

    void Update(){}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            monsterAnim.SetBool("isAttacking",true);
        }
        else
        {
            monsterAnim.SetBool("isAttacking", false);
        }
    
    }
}
