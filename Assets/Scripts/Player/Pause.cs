using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _optionsWindow;
    public static bool GameIsPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pauseMenu.SetActive(false);
        _optionsWindow.SetActive(false);
    }

    public void PauseGame()
    {
        _pauseMenu.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        _pauseMenu.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void SettingsOpen()
    {
        _optionsWindow.SetActive(true);
    }

    public void SettingsClose()
    {
        _optionsWindow.SetActive(false);
    }
}
