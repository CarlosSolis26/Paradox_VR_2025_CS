using UnityEngine;

namespace Others
{
    public class Info9 : MonoBehaviour
    {
        public GameObject info9;
        
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                info9.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                info9.SetActive(false);
            }
        }
    }
}
