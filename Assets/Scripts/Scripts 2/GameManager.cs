using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Scripts_2
{
    public class GameManager : SingletonBase<GameManager>
    {
        [FormerlySerializedAs("txtFin")] public TMP_Text endLevelText;
        [FormerlySerializedAs("goFin")] public GameObject endLevelObject;
        public PlayerHealth playerHealth;
        public GameObject hud;

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
                    //Asignar valor 100 a health text
                    UIManager.Instance.healthText.text = playerHealth.health.ToString();
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
            Time.timeScale = 0;
            EventManager.TriggerEvent("OnGamePause");
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            EventManager.TriggerEvent("OnGameResume");
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