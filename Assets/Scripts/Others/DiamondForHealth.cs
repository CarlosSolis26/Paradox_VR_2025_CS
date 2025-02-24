using Managers;
using UnityEngine;

namespace Others
{
    public class DiamondForHealth : MonoBehaviour
    {
        public void ChangeDiamondForHealth()
        {
            if (GameManager.Instance.currentHealth >= GameManager.Instance.maxHealth) return;
            if (GameManager.Instance.diamonds <= 0) return;
            SoundManager.Instance.PlaySoundButton();
            GameManager.Instance.UpdateDiamonds(-1);
            UIManager.Instance.UpdateSldHealth(1f);
        }
    }
}
