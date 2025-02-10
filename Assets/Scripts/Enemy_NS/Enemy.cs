using System;
using Managers;
using UnityEngine;

namespace Enemy_NS
{
    public class Enemy : MonoBehaviour
    {
        public float damage = 20f;
        
        public GameObject item4;
        public int enemyHealth = 100;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.Instance.UpdateDamageReceived(damage);
            }
        }

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
