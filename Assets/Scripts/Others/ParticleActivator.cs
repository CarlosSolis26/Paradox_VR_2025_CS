using UnityEngine;

namespace Others
{
    public class ParticleActivator : MonoBehaviour
    {
        public ParticleSystem particles;

        public void ActivateParticles()
        {
            particles.Play();
        }
    }
}
