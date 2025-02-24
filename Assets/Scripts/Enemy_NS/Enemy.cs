using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy_NS
{
    public class Enemy : MonoBehaviour
    {
        public float damage = 20f;
        public int enemyHealth = 100;

        public GameObject enemyMesh;
        public GameObject item4;
        public GameObject info6;
        public Transform spawnPoint;
        public Canvas instantiateSphere;
        public Slider sldHealthEnemy;
        public ParticleSystem particle;

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
            UpdateSldHealthEnemy(enemyHealth);
            if (enemyHealth <= 0)
            {
                OnDeathEnemy();
            }
        }

        private void OnDeathEnemy()
        {
            DropItemEnemy();
            particle.Play();
            info6.SetActive(true);
            enemyMesh.SetActive(false);
            instantiateSphere.gameObject.SetActive(false);
            StartCoroutine(IenEnemy());
        }

        private IEnumerator IenEnemy()
        {
            yield return new WaitForSeconds(8);
            particle.Stop();
            info6.SetActive(false);
            Destroy(gameObject);
        }
        
        private void DropItemEnemy()
        {
            Instantiate(item4, spawnPoint.position, Quaternion.identity);
        }

        private void UpdateSldHealthEnemy(float value)
        {
            sldHealthEnemy.value = value;
        }

        public void HideMesh()
        {
            enemyMesh.SetActive(false);
        }
    }
}
