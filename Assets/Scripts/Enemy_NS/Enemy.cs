using System;
using System.Collections;
using Managers;
using UnityEngine;

namespace Enemy_NS
{
    public class Enemy : MonoBehaviour
    {
        public float damage = 20f;
        public int enemyHealth = 100;

        public GameObject enemyMesh;
        public GameObject item4;
        public GameObject info6;

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
                OnDeathEnemy();
            }
        }
        
        public void OnDeathEnemy()
        {
            DropItemEnemy();
            info6.SetActive(true);
            enemyMesh.SetActive(false);
            StartCoroutine(IenEnemy());
        }

        IEnumerator IenEnemy()
        {
            yield return new WaitForSeconds(8);
            info6.SetActive(false);
            Destroy(gameObject);
        }
        
        private void DropItemEnemy()
        {
            Instantiate(item4, transform.position, Quaternion.identity);
        }
    }
}
