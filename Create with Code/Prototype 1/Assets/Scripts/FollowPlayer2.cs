using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer2 : MonoBehaviour
{
 // Variable for player character assignment
    public GameObject player2;
    // Declare camera position
    private Vector3 offset;
    // Define camera Views
    private Vector3 mainPosition = new Vector3(0,4.8f,-7);
    private Vector3 altPosition = new Vector3(0, 2, 0.6f);

    // Declare Camera mode
    // False is mainCamera on, True is altCamera on
    private bool cameraMode;

    // Start is called before the first frame update
    void Start()
    {
        // initialize camera mode and position to main 
        offset = mainPosition;
        cameraMode = false;
        // Reset relative camera rotation
        transform.rotation = player2.transform.rotation;
        // Lock camera rotation to slight downward view
        transform.Rotate(Vector3.right * 15.0f);
    }

    // Update is called once per frame
    void LateUpdate()
    {

        // check if the camera button was pressed, then change mode accordingly
        if (Input.GetButtonUp("Fire1P2"))
            // Call helper method to change cameras
            cameraChange(cameraMode);
        // Update camera position relative to player position
        transform.position = player2.transform.position + offset;
    }

    // cameraChange is called to swap from main view to first person view
    void cameraChange (bool mode)
    {
        // Check what camera mode is active 
        // reverse camera settings accordingly
        if (!mode)
        {
            offset = altPosition;
            cameraMode = true;
        }
        else
        {
            offset = mainPosition;
            cameraMode = false;
        }
        return;
    }
}