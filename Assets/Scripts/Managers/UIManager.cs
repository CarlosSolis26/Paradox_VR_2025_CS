using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager :MonoBehaviour
    {
        public static UIManager Instance;
        
        public TMP_Text txtDiamonds;
        public Slider sldHealth;
        public GameObject panelItems;
        public TMP_Text txtItems;
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

        public void ShowTxtItems(string message)
        {
            panelItems.gameObject.SetActive(true);
            txtItems.text = message;
        }
        
        public void HideTxtItems()
        {
            panelItems.gameObject.SetActive(false);
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
    }
}