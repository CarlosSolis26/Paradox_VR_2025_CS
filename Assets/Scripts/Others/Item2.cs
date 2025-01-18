using UnityEngine;

namespace Others
{
    public class Item2 : MonoBehaviour
    {
        [SerializeField] GameObject wall;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
                Destroy(wall);
            }
        }
    }
}
