using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Declare external Cameras
    public GameObject mainCamera;
    public GameObject altCamera;
    // Define movement speeds
    private float speed = 15.0f;
    private float turnSpeed = 90.0f;
    // Declare inputs
    private float horizontalInput;
    private float forwardInput;
    private bool cameraInput;
    // Declare Camera mode
    // False is mainCamera on, True is altCamera on
    private bool cameraMode;
    
    //************Variables to accompany camera change that involves Cooldowns
    //            See comments in Update method 
    // Declare change detection
    /*
    private bool changeCooldown = false;
    // Declare buffer time counter for camera changing
    private float changeBuffer = 0; */

    void Start()
    {
        // initialize cameras and camera mode
        altCamera.SetActive(false);
        mainCamera.SetActive(true);
        cameraMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Read in Keyboard inputs
        cameraInput = Input.GetButtonUp("Fire1");
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // check if the camera button was pressed and released, then change mode accordingly
        if (cameraInput)
            // Call to helper method to change cameras
            cameraChange(cameraMode);
        // Moves the vehicle forward based on Horizontal button assignment
        transform.Translate (Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Turns the vehicle based on Vertical button assignment
        transform.Rotate (Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        //***************** Old version of camera mode change involving cooldowns, to make sure that the camera only changes once.
        //                  Unnecessary if we can read the negative edge of an input
        // Check camera change input and change camera mode according to input
        /* if (cameraInput)
        {   
            if (!changeCooldown)
            {
                cameraChange(cameraMode);
                changeCooldown = true;
            }
            
        }
        if (changeCooldown)
        {
            changeBuffer++;
            if (changeBuffer > 120)
            {
                changeCooldown = false;
                changeBuffer = 0;
            }
                
        }*/
   
    }

    void cameraChange (bool mode)
    {
        // Check what camera mode is active reverse camera settings accordingly
        if (!mode)
        {
            altCamera.SetActive(true);
            mainCamera.SetActive(false);
            cameraMode = true;
        }
        else
        {
            altCamera.SetActive(false);
            mainCamera.SetActive(true);
            cameraMode = false;
        }
        return;
    }
}
