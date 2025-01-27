using Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Others
{
    public class ScenesChanger : MonoBehaviour
    {
        public void ChangeScene()
        {
            if (SceneManager.GetActiveScene().name == "Intro")
            {
                SceneManager.LoadScene("Level1");
                GameManager.Instance.mainMenu.SetActive(false);
                GameManager.Instance.hud.SetActive(true);
                UIManager.Instance.healthText.text = GameManager.Instance.playerHealth.health.ToString();
            }
            else if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            /*else if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Intro");
            }
            else
            {
                SceneManager.LoadScene("Game");
            }*/
        }
    }
}
