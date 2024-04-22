using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Variable for player character assignment
    public GameObject player;
    // Declare camera position
    private Vector3 offset = new Vector3(0,4.8f,-7);


    // Start is called before the first frame update
    void Start()
    {
        // Reset camera rotation
        transform.rotation = player.transform.rotation;
        // Lock camera rotation to slight downward view
        transform.Rotate(Vector3.right * 15.0f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Update camera position relative to player position
        transform.position = player.transform.position + offset;
    }
}
