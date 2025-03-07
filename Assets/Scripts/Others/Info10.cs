using UnityEngine;

namespace Others
{
    public class Info10 : MonoBehaviour
    {
        public GameObject info10;
        
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                info10.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                info10.SetActive(false);
            }
        }
    }
}
