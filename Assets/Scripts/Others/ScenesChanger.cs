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
                SceneManager.LoadScene("Game");
            }
            else if (SceneManager.GetActiveScene().name == "Game")
            {
                SceneManager.LoadScene("Game 1");
            }
            else if (SceneManager.GetActiveScene().name == "Game 1")
            {
                SceneManager.LoadScene("Game 2");
            }
            else
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
}
