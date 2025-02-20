using Managers;
using UnityEngine;

namespace Others
{
    public class DiamondForHealth : MonoBehaviour
    {
        public void ChangeDiamondForHealth()
        {
            if (GameManager.Instance.diamonds <= 0) return;
            GameManager.Instance.UpdateDiamonds(-1);
            UIManager.Instance.UpdateSldHealth(1f);
        }
    }
}
