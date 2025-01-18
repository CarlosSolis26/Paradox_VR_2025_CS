using UnityEngine;

namespace Scripts_2
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