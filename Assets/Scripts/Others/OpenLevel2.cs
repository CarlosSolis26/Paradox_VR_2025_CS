using Managers;
using UnityEngine;

namespace Others
{
    public class OpenLevel2 : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.Instance.Level2();
            }
        }
    }
}
