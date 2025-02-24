using System;
using UnityEngine;

namespace Others
{
    public class Info2 : MonoBehaviour
    {
        public GameObject info2;
        
        private void OnTriggerStay(Collider other)
        {
            info2.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        {
            info2.SetActive(false);
        }
    }
}
