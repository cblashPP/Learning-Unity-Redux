using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
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
        cameraInput = Input.GetButtonUp("Fire1P2");
        horizontalInput = Input.GetAxis("HorizontalP2");
        forwardInput = Input.GetAxis("VerticalP2");
        // check if the camera button was pressed and released, then change mode accordingly
        if (cameraInput)
            // Call to helper method to change cameras
            cameraChange(cameraMode);
        // Moves the vehicle forward based on Horizontal button assignment
        transform.Translate (Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Turns the vehicle based on Vertical button assignment
        transform.Rotate (Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
   
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
