using System;
using UnityEngine;

public class TestCube1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
