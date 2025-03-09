using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Testing.Scripts
{
public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string startScene;
    
    public void LoadStartScene()
    {
        SceneManager.LoadScene(startScene);
        GameManager.Instance.mainMenu.SetActive(false);
        UIManager.Instance.ActivateHud();
    }
}
}
