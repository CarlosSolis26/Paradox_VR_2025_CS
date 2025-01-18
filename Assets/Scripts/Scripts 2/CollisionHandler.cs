using UnityEngine;

namespace Scripts_2
{
    public class CollisionHandler : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collision with: " + collision.gameObject.name);
        }
    }
}