using Enemy_NS;
using Managers;
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
                //SoundManager.Instance.PlaySoundDamageEnemy();
                Destroy(gameObject);
            }
        }
    }
}
