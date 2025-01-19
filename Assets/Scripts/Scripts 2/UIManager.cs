using TMPro;
using UnityEngine;

namespace Scripts_2
{
    public class UIManager : SingletonBase<UIManager>
    {
        public TextMeshProUGUI messageText;
        public TextMeshProUGUI healthText;

        private void OnEnable()
        {
            // Subscribe to events
            EventManager.StartListening("OnPlayerHealthChanged", UpdateHealthUI);
            EventManager.StartListening("OnPlayerDeath", ShowGameOverScreen);
        }

        private void OnDisable()
        {
            // Unsubscribe from events
            EventManager.StopListening("OnPlayerHealthChanged", UpdateHealthUI);
            EventManager.StopListening("OnPlayerDeath", ShowGameOverScreen);
        }

        private void UpdateHealthUI()
        {
            //healthText.text = "Health: " + Managers.GameManager.Instance.playerHealth.health;
        }

        private void ShowGameOverScreen()
        {
            Debug.Log("Game Over!");
            // Add logic to display a game over screen
        }

        public void ShowMessage(string message)
        {
            messageText.text = message;
            messageText.gameObject.SetActive(true);
        }
    }
}