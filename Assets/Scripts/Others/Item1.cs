using UnityEngine;

namespace Others
{
    public class Item1 : MonoBehaviour, IDestroy
    {
        [SerializeField] private GameObject wall;

        public void DestroyItemObject()
        {
            Destroy(gameObject);
            Destroy(wall);
        }
    }
}
