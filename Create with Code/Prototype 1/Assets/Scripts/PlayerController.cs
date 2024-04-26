using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Declare Player 2
    public GameObject playerTwo;

    // Declare external camera object to manipulate camera display ratios
    public Camera playerCam;

    // Define movement speeds
    private float speed = 15.0f;
    private float turnSpeed = 90.0f;

    // Declare inputs
    private float horizontalInput;
    private float forwardInput;
    private bool multiplayerToggle;
    
    // Declare Multiplayer status variable
    // Once enabled the multiplayer will stay on
    private bool multiplayerOn;
    void Start()
    {
        // initialize camera display
        playerCam.rect = new Rect(0,0,1,1);

        // Set player 2 as off and multiplayer as disabled
        playerTwo.SetActive(false);
        multiplayerOn = false;


    }

    // Update is called once per frame
    void Update()
    {
        // Read in Keyboard inputs
        multiplayerToggle = Input.GetButtonDown("Jump");
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Moves the vehicle forward based on Horizontal button assignment
        transform.Translate (Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Turns the vehicle based on Vertical button assignment
        transform.Rotate (Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
         
        // Check if multiplayer toggle was pressed and if multiplayer isn't already on
        if (multiplayerToggle && !multiplayerOn)
            // Call helper method to start multiplayer
            enableMulti();
    }


    // enableMulti is called to add the second player to the game and resize the screen accordingly
    void enableMulti ()
    {
        // Change camera window display sizes
        playerCam.rect = new Rect(0.5f,0,0.5f,1);

        // Enable the second player's access
        playerTwo.SetActive(true);
        // Set multiplayer mode indicater on
        multiplayerOn = true;
        return;
    }
}
