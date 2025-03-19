using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public int diamonds;
        public float maxHealth = 100f;
        public float currentHealth;
        
        public GameObject mainMenu;
        public GameObject pauseMenu;
        public GameObject locomotionSystem;

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
            currentHealth = maxHealth;
        }

        public void UpdateDiamonds(int diamonds)
        {
            this.diamonds += diamonds;
            UIManager.Instance.UpdateTxtDiamonds(this.diamonds.ToString());
            print(this.diamonds);
        }

        public void UpdateDamageReceived(float value)
        {
            float reduceLife = currentHealth - value;
            SoundManager.Instance.PlaySoundDamagePlayer();
            if (reduceLife > 0f)
            {
                currentHealth = reduceLife;
                UIManager.Instance.UpdateSldHealth(currentHealth/maxHealth);
            }
            else
            {
                currentHealth = 0f;
                UIManager.Instance.UpdateSldHealth(0f);
                locomotionSystem.SetActive(false);
                UIManager.Instance.ShowScreenFinal("HAS PERDIDO");
            }
        }
        
        public void StartGame()
        {
            SoundManager.Instance.StopMusicMenu();
            SceneManager.LoadScene("Level1");
            SoundManager.Instance.PlayMusicGame();
            mainMenu.SetActive(false);
        }

        public void RestartGame()
        {
            UIManager.Instance.HideScreenFinal();
            SceneManager.LoadScene("Level1");
            locomotionSystem.SetActive(true);
            SoundManager.Instance.PlayMusicGame();
        }

        public void Menu()
        {
            locomotionSystem.SetActive(true);
            SceneManager.LoadScene("Intro");
            pauseMenu.SetActive(false);
            mainMenu.SetActive(true);
        }

        public void Level2()
        {
            SceneManager.LoadScene("Level2");
        }

        public void QuitGame()
        {
            SoundManager.Instance.StopMusicMenu();
            Application.Quit();
        }

        public void PauseGame()
        {
            pauseMenu.SetActive(true);
            SoundManager.Instance.StopMusicGame();
            SoundManager.Instance.PlayMusicMenu();
            locomotionSystem.SetActive(false);
        }

        public void ResumeGame()
        {
            pauseMenu.SetActive(false);
            SoundManager.Instance.StopMusicMenu();
            SoundManager.Instance.PlayMusicGame();
            locomotionSystem.SetActive(true);
        }
    }
}