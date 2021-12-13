using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupChildObjectPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if(transform.position != transform.parent.position)
        {
            //Stops inner power up from spawn outside of helth outer power up container
            transform.parent.position = transform.position;
            transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
