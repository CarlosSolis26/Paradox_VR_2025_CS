using Managers;
using UnityEngine;

namespace Others
{
    public class Item4 : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                SoundManager.Instance.PlaySoundCylinder();
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
