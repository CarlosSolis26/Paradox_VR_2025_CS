using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts_2
{
    public class ScenesChanger : MonoBehaviour
    {
        public void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}