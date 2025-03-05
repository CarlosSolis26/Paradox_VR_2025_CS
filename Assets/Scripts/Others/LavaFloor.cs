using Managers;
using UnityEngine;

namespace Others
{
    public class LavaFloor : MonoBehaviour
    {
        public float damage = 20f;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.Instance.UpdateDamageReceived(damage);
            }
        }
    }
}
