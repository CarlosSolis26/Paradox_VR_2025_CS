using Enemy_NS;
using UnityEngine;

namespace Others{
public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeSpan;
    [SerializeField] private int damageAmount = 20;

    private void Start()
    {
        Destroy(gameObject, lifeSpan);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount);
            }
        }
    }
}
}