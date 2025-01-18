using UnityEngine;

namespace Scripts_2
{
    public class SoundPlayer : MonoBehaviour
    {
        public AudioSource audioSource;

        private void OnCollisionEnter(Collision collision)
        {
            audioSource.Play();
        }
    }
}