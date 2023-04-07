using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAnimation : MonoBehaviour
{
    public float floatSpeed = 3f; // Speed of the floating animation
    public float floatHeight = 0.1f; // Height of the float

    private Vector3 startPos; // Starting position of the object

    void Start()
    {
        startPos = transform.position; // Store the starting position of the object
    }

    void Update()
    {
        // Calculate the new Y position for the object based on the sine of the current time
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight + startPos.y;

        // Set the object's position to the new Y position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
