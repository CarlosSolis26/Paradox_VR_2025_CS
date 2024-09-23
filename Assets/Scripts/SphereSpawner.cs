using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject spherePrefab; // Prefab de la esfera
    public Transform spawnPoint; // Punto de aparición

    public void SpawnSphere()
    {
        Instantiate(spherePrefab, spawnPoint.position, Quaternion.identity);
    }
}
