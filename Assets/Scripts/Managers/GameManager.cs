using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        //[SerializeField] private string newLevel;
        public int diamonds;
        public float maxHealth = 100f;
        public float currentHealth;
        
        //public TMP_Text endLevelText;
        //public GameObject endLevelObject;
        //public PlayerHealth playerHealth;
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
                UIManager.Instance.DeactivateHud();
                locomotionSystem.SetActive(false);
                UIManager.Instance.ShowScreenFinal("HAS PERDIDO");
            }
        }
        
        private void OnEnable()
        {
            //SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            //SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        /*private void OnSceneLoaded(Scene sc, LoadSceneMode lsm)
        {
            if (sc.name == "Intro")
            {
                //hud.SetActive(false);
            }
            else
            {
                if (sc.name == "Level1")
                {
                    //Asign value 100 to health text
                    //UIManager.Instance.healthText.text = playerHealth.health.ToString();
                    //mainMenu.SetActive(false);
                    //hud.SetActive(true);
                }
            }
        }*/

        public void StartGame()
        {
            //if (SceneManager.GetActiveScene().name == "Intro")
            //{
            SoundManager.Instance.StopmusicMenu();
            SceneManager.LoadScene("Level1");
            SoundManager.Instance.PlayMusicGame();
            mainMenu.SetActive(false);
            UIManager.Instance.ActivateHud();
            //}
            //else if (SceneManager.GetActiveScene().name == "Level1")
            //{
                //SceneManager.LoadScene("Level2");
            //}
            /*else if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Intro");
            }
            else
            {
                SceneManager.LoadScene("Game");
            }*/
        }

        public void RestartGame()
        {
            UIManager.Instance.HideScreenFinal();
            SceneManager.LoadScene("Level1");
            locomotionSystem.SetActive(true);
            SoundManager.Instance.PlayMusicGame();
            UIManager.Instance.ActivateHud();
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
            SoundManager.Instance.StopmusicMenu();
            Application.Quit();
        }

        public void PauseGame()
        {
            pauseMenu.SetActive(true);
            SoundManager.Instance.StopMusicGame();
            SoundManager.Instance.PlayMusicMenu();
            UIManager.Instance.DeactivateHud();
            locomotionSystem.SetActive(false);
            //Time.timeScale = 0;
            //EventManager.TriggerEvent("OnGamePause");
        }

        public void ResumeGame()
        {
            pauseMenu.SetActive(false);
            SoundManager.Instance.StopmusicMenu();
            SoundManager.Instance.PlayMusicGame();
            UIManager.Instance.ActivateHud();
            locomotionSystem.SetActive(true);
            //Time.timeScale = 1;
            //EventManager.TriggerEvent("OnGameResume");
        }

        /*public void Interact(Collider other)
        {
            IDestroy destroy = other.GetComponent<IDestroy>();
            if (destroy != null)
            {
                destroy.DestroyItemObject();
            }
        }*/

        /*public void EndLevel(bool success)
        {
            if (success)
            {
                UIManager.Instance.ShowMessage("¡Felicidades! Nivel completado.");
            }
            else
            {
                UIManager.Instance.ShowMessage("Reinicia el nivel.");
            }
        }*/

        /*public void ShowEndScreen(string message)
        {
            endLevelObject.SetActive(true);
            endLevelText.text = message;
        }*/

        /*private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //Destroy(other.gameObject);
                ShowEndScreen("HAS GANADO");
            }
        }*/
    }
}