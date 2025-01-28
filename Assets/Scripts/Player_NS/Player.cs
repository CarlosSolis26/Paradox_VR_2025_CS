using Others;
using UnityEngine;

namespace Player_NS
{
    public class Player : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var iDestroy = other.gameObject.GetComponent<IDestroy>();

            if (iDestroy != null)
            {
                iDestroy.DestroyItemObject();
            }
        }
    }
}
