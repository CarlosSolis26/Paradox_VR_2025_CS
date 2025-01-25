using Player_NS;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        
        public static GameManager Instance;
        public TMP_Text endLevelText;
        public GameObject endLevelObject;
        public PlayerHealth playerHealth;
        public GameObject hud;
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
        
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene sc, LoadSceneMode lsm)
        {
            if (sc.name == "Intro")
            {
                hud.SetActive(false);
            }
            else
            {
                if (sc.name == "VR_Scene_1_CS")
                {
                    //Asign value 100 to health text
                    UIManager.Instance.healthText.text = playerHealth.health.ToString();
                    Destroy(mainMenu);
                    //mainMenu.SetActive(false);
                    hud.SetActive(true);
                }
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P)) PauseGame();
            else if (Input.GetKeyDown(KeyCode.R)) ResumeGame();
        }

        public void StartGame()
        {
            Debug.Log("Game Started!");
        }

        public void PauseGame()
        {
            pauseMenu.SetActive(true);
            hud.SetActive(false);
            locomotionSystem.SetActive(false);
            //Time.timeScale = 0;
            //EventManager.TriggerEvent("OnGamePause");
        }

        public void ResumeGame()
        {
            pauseMenu.SetActive(false);
            hud.SetActive(true);
            locomotionSystem.SetActive(true);
            //Time.timeScale = 1;
            //EventManager.TriggerEvent("OnGameResume");
        }

        public void EndLevel(bool success)
        {
            if (success)
            {
                UIManager.Instance.ShowMessage("¡Felicidades! Nivel completado.");
            }
            else
            {
                UIManager.Instance.ShowMessage("Reinicia el nivel.");
            }
        }

        public void ShowEndScreen(string message)
        {
            endLevelObject.SetActive(true);
            endLevelText.text = message;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //Destroy(other.gameObject);
                ShowEndScreen("HAS GANADO");
            }
        }
    }
}