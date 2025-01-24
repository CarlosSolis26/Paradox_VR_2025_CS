using UnityEngine;

namespace Scripts_2
{
    public class SoundPlayer : MonoBehaviour
    {
        public AudioSource audioSource;
        
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                audioSource.Play();
            }
        }
    }
}