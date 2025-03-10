using Enemy_NS;
using UnityEngine;

namespace Others
{
    public class SphereDamage : MonoBehaviour
    {
        public int damageAmount = 20;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                var enemyHealth = other.gameObject.GetComponent<Enemy>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damageAmount);
                }
                Destroy(gameObject);
            }
        }
    }
}
