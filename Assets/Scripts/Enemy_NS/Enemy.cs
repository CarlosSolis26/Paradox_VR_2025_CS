using UnityEngine;

namespace Enemy_NS
{
    public class Enemy : MonoBehaviour
    {
        public GameObject item4;
        public int enemyHealth = 100;

        public void TakeDamage(int damage)
        {
            enemyHealth -= damage;
            if (enemyHealth <= 0)
            {
                OnDeath();
            }
        }
        
        public void OnDeath()
        {
            DropItem();
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
        
        private void DropItem()
        {
            Instantiate(item4, transform.position, Quaternion.identity);
        }
    }
}
