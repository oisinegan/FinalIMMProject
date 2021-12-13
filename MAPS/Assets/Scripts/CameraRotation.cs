using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float xCameraRotationSpeed = 1f;
    public float yCameraRotationSpeed = 1f;
    float verticalInput = 0.0f;
    float horizontalInput = 0.0f;
   
    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       if (GameManager.isGameActive)
        {
            //get input for horizontal and vertical movement
            verticalInput = verticalInput - yCameraRotationSpeed * Input.GetAxis("Mouse Y");
            horizontalInput = horizontalInput + xCameraRotationSpeed * Input.GetAxis("Mouse X");
            float yLimits = Mathf.Clamp(verticalInput, -80f, 80);
            transform.eulerAngles = new Vector3(yLimits, horizontalInput, 0.0f);
       }
    }
 }
