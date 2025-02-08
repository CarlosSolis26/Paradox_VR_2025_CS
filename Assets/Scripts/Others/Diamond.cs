using Managers;
using UnityEngine;

namespace Others
{
    public class Diamond : MonoBehaviour, IDestroy
    {
        public void DestroyItemObject()
        {
            GameManager.Instance.UpdateDiamonds(1);
            Destroy(gameObject);
        }
    }
}
