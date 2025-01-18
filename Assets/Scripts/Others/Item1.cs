using UnityEngine;

namespace Others
{
    public class Item1 : MonoBehaviour
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
