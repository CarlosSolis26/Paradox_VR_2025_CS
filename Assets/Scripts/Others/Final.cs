using Managers;
using UnityEngine;

namespace Others
{
    public class Final : MonoBehaviour
    {
        public ParticleSystem particle;
        public ParticleSystem particleAuraFin;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                particle.Play();
                particleAuraFin.Play();
                SoundManager.Instance.PlaySoundWin();
                UIManager.Instance.DeactivateHud();
                GameManager.Instance.locomotionSystem.SetActive(false);
                UIManager.Instance.ShowScreenFinal("HAS GANADO");
            }
        }
    }
}
