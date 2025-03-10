using UnityEngine;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        
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
        }

        private void Start()
        {
            PlayMusicMenu();
        }

        public void PlayMusicMenu()
        {
            musicMenu.Play();
        }

        public void StopMusicMenu()
        {
            musicMenu.Stop();
        }

        public void PlayMusicGame()
        {
            musicGame.Play();
        }

        public void StopMusicGame()
        {
            musicGame.Pause();
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
    }
}