using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

//using UnityEngine.SceneManagement;

namespace Managers
{
    public class UIManager :MonoBehaviour
    {
        public static UIManager Instance;
        
        public TMP_Text txtDiamonds;
        public Slider sldHealth;
        public TMP_Text showTxtDiamonds;
        public GameObject hud;
        [FormerlySerializedAs("screenDeath")] public GameObject screenFinal;
        [FormerlySerializedAs("txtDeath")] public TMP_Text txtFinal;
        
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
            UpdateSldHealth(1f);
            UpdateTxtDiamonds("0");
        }

        public void UpdateSldHealth(float value)
        {
            sldHealth.value = value;
        }
        
        public void UpdateTxtDiamonds(string text)
        {
            txtDiamonds.text = text;
        }

        public void ShowTxtDiamonds()
        {
            showTxtDiamonds.gameObject.SetActive(true);
        }
        
        public void HideTxtDiamonds()
        {
            showTxtDiamonds.gameObject.SetActive(false);
        }

        public void ActivateHud()
        {
            hud.SetActive(true);
        }

        public void DeactivateHud()
        {
            hud.SetActive(false);
        }

        public void ShowScreenFinal(string message)
        {
            screenFinal.SetActive(true);
            txtFinal.text = message;
        }
        
        public void HideScreenFinal()
        {
            screenFinal.SetActive(false);
        }
        
        private void OnEnable()
        {
            // Subscribe to events
            //EventManager.StartListening("OnPlayerHealthChanged", UpdateHealthUI);
            //EventManager.StartListening("OnPlayerDeath", ShowGameOverScreen);
            
            //SceneManager.sceneLoaded += OnSceneLoaded;

        }

        private void OnDisable()
        {
            // Unsubscribe from events
            //EventManager.StopListening("OnPlayerHealthChanged", UpdateHealthUI);
            //EventManager.StopListening("OnPlayerDeath", ShowGameOverScreen);
            
            //SceneManager.sceneLoaded -= OnSceneLoaded;

        }
        
        /*private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            Debug.Log("SceneLoadedFromUIManager");
        }*/
        
        /*private void UpdateHealthUI()
        {
            healthText.text = "Health: " + Managers.GameManager.Instance.playerHealth.health;
        }*/

        /*private void ShowGameOverScreen()
        {
            Debug.Log("Game Over!");
            // Add logic to display a game over screen
        }*/

        /*public void ShowMessage(string message)
        {
            messageText.text = message;
            messageText.gameObject.SetActive(true);
        }*/
    }
}