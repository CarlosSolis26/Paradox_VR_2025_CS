using UnityEngine;

namespace Others
{
    public class Info8 : MonoBehaviour
    {
        public GameObject info8;
        
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                info8.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                info8.SetActive(false);
            }
        }
    }
}
