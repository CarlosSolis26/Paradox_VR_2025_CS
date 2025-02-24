using Others;
using UnityEngine;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
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

        
        public AudioSource musicMenu;
        public AudioSource musicGame;
        public AudioSource soundDiamond;
        public AudioSource soundSphere;
        public AudioSource soundDamageEnemy;
        public AudioSource soundDamagePlayer;
        public AudioSource soundWin;
        public AudioSource soundButton;
        public AudioSource soundCylinder;

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

            //soundEffectSource = gameObject.AddComponent<AudioSource>();

            //backgroundMusicSource.loop = true;
        }

        private void Start()
        {
            //PlayBackgroundMusicNormal();
            PlayMusicMenu();
            
        }

        public void PlayMusicMenu()
        {
            musicMenu.Play();
        }

        public void StopmusicMenu()
        {
            musicMenu.Stop();
        }

        public void PlayMusicGame()
        {
            musicGame.Play();
        }

        public void StopMusicGame()
        {
            musicGame.Stop();
        }

        public void PlaySoundDiamond()
        {
            soundDiamond.Play();
        }

        public void PlaySoundSphere()
        {
            soundSphere.Play();
        }

        public void PlaySoundDamageEnemy()
        {
            soundDamageEnemy.Play();
        }

        public void PlaySoundDamagePlayer()
        {
            soundDamagePlayer.Play();
        }

        public void PlaySoundWin()
        {
            soundWin.Play();
        }

        public void PlaySoundButton()
        {
            soundButton.Play();
        }

        public void PlaySoundCylinder()
        {
            soundCylinder.Play();
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

        /*public void PlayBackgroundMusicNormal()
        {
            if (backgroundMusicSource.clip != backgroundMusicNormal)
            {
                backgroundMusicSource.clip = backgroundMusicNormal;
                backgroundMusicSource.Play();
            }
        }*/

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