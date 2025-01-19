using UnityEngine;

namespace Scripts_2
{
    public class LevelController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            //if (other.CompareTag("Player")) Managers.GameManager.Instance.EndLevel(true); // Level completed
        }
    }
}