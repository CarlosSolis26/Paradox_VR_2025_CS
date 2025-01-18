using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts_2
{
    public class GameManager : SingletonBase<GameManager>
    {
        [FormerlySerializedAs("txtFin")] public TMP_Text endLevelText;
        [FormerlySerializedAs("goFin")] public GameObject endLevelObject;
        public PlayerHealth playerHealth;

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