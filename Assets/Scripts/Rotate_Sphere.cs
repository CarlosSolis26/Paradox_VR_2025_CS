using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Sphere : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of rotation

    void Update()
    {
        // Rotate the sphere around its own Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
