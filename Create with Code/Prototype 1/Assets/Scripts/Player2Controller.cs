using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    
    // Define movement speeds
    private float speed = 15.0f;
    private float turnSpeed = 90.0f;
    // Declare inputs
    private float horizontalInput;
    private float forwardInput;

    // Update is called once per frame
    void Update()
    {
        // Read in Keyboard inputs
        horizontalInput = Input.GetAxis("HorizontalP2");
        forwardInput = Input.GetAxis("VerticalP2");
        // Moves the vehicle forward based on Horizontal button assignment
        transform.Translate (Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Turns the vehicle based on Vertical button assignment
        transform.Rotate (Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
   
    }
}
