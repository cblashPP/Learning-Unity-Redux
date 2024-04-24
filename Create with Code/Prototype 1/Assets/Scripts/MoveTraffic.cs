using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTraffic : MonoBehaviour
{
    // Declare movement speed
    private float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        // Move traffic car forward at constant speed throughout game time
        transform.Translate (Vector3.forward * speed * Time.deltaTime);
    }
}
