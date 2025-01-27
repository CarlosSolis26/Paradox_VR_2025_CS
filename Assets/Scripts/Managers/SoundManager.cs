using UnityEngine;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        // Singleton instance
        public static SoundManager Instance;

        public AudioClip objectSound1;
        public AudioClip objectSound2;
        public AudioClip objectSound3;

        public AudioClip buttonSound1;
        public AudioClip buttonSound2;
        public AudioClip buttonSound3;

        public AudioClip backgroundMusicNormal;
        public AudioClip backgroundMusicGameOver;

        private AudioSource soundEffectSource;

        public AudioSource backgroundMusicSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            soundEffectSource = gameObject.AddComponent<AudioSource>();

            backgroundMusicSource.loop = true;
        }

        private void Start()
        {
            PlayBackgroundMusicNormal();
        }

        public void PlayObjectSound1()
        {
            soundEffectSource.PlayOneShot(objectSound1);
        }

        public void PlayObjectSound2()
        {
            soundEffectSource.PlayOneShot(objectSound2);
        }

        public void PlayObjectSound3()
        {
            soundEffectSource.PlayOneShot(objectSound3);
        }

        public void PlayButtonSound1()
        {
            soundEffectSource.PlayOneShot(buttonSound1);
        }

        public void PlayButtonSound2()
        {
            soundEffectSource.PlayOneShot(buttonSound2);
        }

        public void PlayButtonSound3()
        {
            soundEffectSource.PlayOneShot(buttonSound3);
        }

        public void PlayBackgroundMusicNormal()
        {
            if (backgroundMusicSource.clip != backgroundMusicNormal)
            {
                backgroundMusicSource.clip = backgroundMusicNormal;
                backgroundMusicSource.Play();
            }
        }

        public void PlayBackgroundMusicGameOver()
        {
            if (backgroundMusicSource.clip != backgroundMusicGameOver)
            {
                backgroundMusicSource.clip = backgroundMusicGameOver;
                backgroundMusicSource.Play();
            }
        }

        public void StopBackgroundMusic()
        {
            backgroundMusicSource.Stop();
        }
    }
}