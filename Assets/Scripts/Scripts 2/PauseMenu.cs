using UnityEngine;

namespace Scripts_2
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject pausePanel;
        private bool isPaused = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P)) TogglePause();
        }

        public void TogglePause()
        {
            isPaused = !isPaused;
            pausePanel.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;
        }
    }
}