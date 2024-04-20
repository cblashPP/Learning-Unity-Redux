using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayerX : MonoBehaviour
{
    // Variable to link plane
    public GameObject plane;

    // position offset of camera
    private Vector3 offset = new Vector3 (18, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        // Reset camera rotation
        transform.rotation = plane.transform.rotation;
        // lock camera to side view rotation
        transform.Rotate(Vector3.up * -90);
    }

    // Update is called once per frame
    void Update()
    {
        // set camera position relative to plane
        transform.position = plane.transform.position + offset;
    }
}
