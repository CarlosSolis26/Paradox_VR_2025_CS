using Managers;
using UnityEngine;

namespace Others
{
    public class SphereSpawner : MonoBehaviour
    {
        public GameObject spherePrefab; // Prefab de la esfera
        public Transform spawnPoint; // Punto de aparición

        public void SpawnSphere()
        {
            SoundManager.Instance.PlaySoundButton();
            Instantiate(spherePrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
