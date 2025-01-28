using UnityEngine;

namespace Others
{
    public class Item1 : MonoBehaviour, IDestroy
    {
        [SerializeField] private GameObject wall;

        /*public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
                Destroy(wall);
            }
        }*/

        public void DestroyItemObject()
        {
            Destroy(gameObject);
            Destroy(wall);
        }
    }
}
