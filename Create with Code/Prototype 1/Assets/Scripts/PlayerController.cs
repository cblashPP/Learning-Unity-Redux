using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Declare Player 2
    public GameObject playerTwo;
    // Declare external Cameras
    public GameObject mainCamera;
    public GameObject altCamera;

    // *** Declare external camera objects
    //     This is variable type is needed to manipulate camera display ratios
    public Camera altCam;
    public Camera mainCam;

    // Define movement speeds
    private float speed = 15.0f;
    private float turnSpeed = 90.0f;
    
    // Declare inputs
    private float horizontalInput;
    private float forwardInput;
    private bool multiplayerToggle;
    private bool cameraInput;

    // Declare Camera mode
    // False is mainCamera on, True is altCamera on
    private bool cameraMode;
    // Declare Multiplayer status variable
    // Once enabled the multiplayer will stay on
    private bool multiplayerOn;
    void Start()
    {
        // initialize cameras and camera mode
        altCam.rect = new Rect(0,0,1,1);
        altCamera.SetActive(false);
        mainCam.rect = new Rect(0,0,1,1);
        mainCamera.SetActive(true);
        cameraMode = false;

        // Set player 2 as off and multiplayer as disabled
        playerTwo.SetActive(false);
        multiplayerOn = false;


    }

    // Update is called once per frame
    void Update()
    {
        // Read in Keyboard inputs
        multiplayerToggle = Input.GetButtonDown("Jump");
        cameraInput = Input.GetButtonUp("Fire1");
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Moves the vehicle forward based on Horizontal button assignment
        transform.Translate (Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Turns the vehicle based on Vertical button assignment
        transform.Rotate (Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        
        // check if the camera button was pressed, then change mode accordingly
        if (cameraInput)
            // Call helper method to change cameras
            cameraChange(cameraMode);
         
        // Check if multiplayer toggle was pressed and if multiplayer isn't already on
        if (multiplayerToggle && !multiplayerOn)
            // Call helper method to start multiplayer
            enableMulti();
    }

    // cameraChange is called to swap from main view to first person view
    void cameraChange (bool mode)
    {
        // Check what camera mode is active 
        // reverse camera settings accordingly
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

    // enableMulti is called to add the second player to the game and resize the screen accordingly
    void enableMulti ()
    {
        // Change camera window display sizes
        altCam.rect = new Rect(0.5f,0,0.5f,1);
        mainCam.rect = new Rect(0.5f,0,0.5f,1);

        // Enable the second player's access
        playerTwo.SetActive(true);
        // Set multiplayer mode indicater on
        multiplayerOn = true;
        return;
    }
}
