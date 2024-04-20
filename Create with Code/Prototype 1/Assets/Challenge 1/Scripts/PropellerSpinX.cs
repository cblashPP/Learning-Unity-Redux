using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpinX : MonoBehaviour
{
    // Declare rotation speed
    private float rotateSpeed = 150;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate propeller
        transform.Rotate(Vector3.forward * rotateSpeed);
    }
}
