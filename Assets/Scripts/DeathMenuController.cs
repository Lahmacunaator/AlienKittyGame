using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour
{
    public void OnMainMenuButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }
    
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
