using UnityEngine;

namespace Enemy_NS
{
    public class Enemy : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
