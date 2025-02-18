using UnityEngine;

namespace Others
{
public class BulletSpawner: MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float bulletSpeed; 

    public void SpawnBullet()
    {
        var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        var bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // Apply velocity to the bullet to move it forward
        bulletRigidbody.linearVelocity = spawnPoint.forward * bulletSpeed;
    }
}
}