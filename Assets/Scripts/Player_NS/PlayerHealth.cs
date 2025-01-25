using Managers;
using UnityEngine;

namespace Player_NS
{
    public class PlayerHealth : MonoBehaviour
    {
        public int health = 100;
        public int changeHealth = 5;

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                EventManager.TriggerEvent("OnPlayerDeath");
            }

            EventManager.TriggerEvent("OnPlayerHealthChanged");
        }

        public void AddHealth(int amount)
        {
            health += amount;
        }

        public void AddHealth()
        {
            health += changeHealth;
            //uiManagerVar.healthText.text = health.ToString();
            UIManager.Instance.healthText.text = health.ToString();
            Debug.Log("Health: "+health);
        }

        public void ReduceHealth()
        {
            health -= changeHealth;
            //uiManagerVar.healthText.text = health.ToString();
            UIManager.Instance.healthText.text = health.ToString();
            Debug.Log("Health: "+health);
        }

        public void AddHealth(float amount)
        {
            
        }
    }
}