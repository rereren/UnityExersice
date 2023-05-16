using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    
    private int previousSceneIndex;

    public void OnPauseButtonClicked()
    {
        SceneManager.LoadScene("PauseMenu");
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("LevelSelect");       
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Level1()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Level2()
    {
        SceneManager.LoadScene("MainGameLv2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("MainGameLv3");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame()
    {
        // Exit the application (works in standalone builds)
        Application.Quit();
    }
}
