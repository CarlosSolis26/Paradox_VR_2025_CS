using System;
using Others;
using Player_NS;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        //public TMP_Text endLevelText;
        //public GameObject endLevelObject;
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
                SceneManager.LoadScene("Level1");
                UIManager.Instance.healthText.text = playerHealth.health.ToString();
                mainMenu.SetActive(false);
                hud.SetActive(true);
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

        public void QuitGame()
        {
            Application.Quit();
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