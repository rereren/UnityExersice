using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    private bool isPaused = false;

    public void OnPauseButtonClicked()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;

        if (isPaused)
        {
            SceneManager.LoadScene("PauseMenu");
        }
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            SceneManager.LoadScene("MainGame");
            Time.timeScale = 1f;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("MainGame");
        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}