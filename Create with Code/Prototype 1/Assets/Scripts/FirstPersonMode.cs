using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstPersonMode : MonoBehaviour
{
    public GameObject player;
    public GameObject altCamera;
    private bool cameraInput;

    // Define relative camera position
    private Vector3 offset = new Vector3 (0, 2, 0.6f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraInput = Input.GetButton("Fire1");
        altCamera.SetActive(true);

    }
}
