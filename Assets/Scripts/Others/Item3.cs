using UnityEngine;

namespace Others
{
    public class Item3 : MonoBehaviour
    {
        [SerializeField] GameObject enemy;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
                Destroy(enemy);
            }
        }
    }
}
