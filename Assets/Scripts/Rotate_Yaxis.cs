using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Yaxis : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of rotation

    public bool rotateAroundX = false; // Toggle to rotate around the X-axis
    public bool rotateAroundY = true;  // Toggle to rotate around the Y-axis
    public bool rotateAroundZ = false; // Toggle to rotate around the Z-axis

    void Update()
    {
        // Determine the direction of rotation based on toggles
        Vector3 rotationDirection = Vector3.zero;

        if (rotateAroundX)
            rotationDirection += Vector3.right;

        if (rotateAroundY)
            rotationDirection += Vector3.up;

        if (rotateAroundZ)
            rotationDirection += Vector3.forward;

        // Rotate around the chosen axis/axes
        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
