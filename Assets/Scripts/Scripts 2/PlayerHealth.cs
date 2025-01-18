using UnityEngine;

namespace Scripts_2
{
    public class PlayerHealth : MonoBehaviour
    {
        public int health = 100;

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
    }
}