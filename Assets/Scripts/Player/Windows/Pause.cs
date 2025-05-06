using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _optionsWindow;
    [SerializeField] private GameObject _vicotryWindow;
    [SerializeField] private GameObject _defeatWindow;
    public static bool GameIsPaused = false;
    private PlayerGetHit _playerGetHitScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CleanResumeGame();
        _pauseMenu.SetActive(false);
        _optionsWindow.SetActive(false);
        _vicotryWindow.SetActive(false);
        _defeatWindow.SetActive(false);

        var player = GameObject.FindGameObjectWithTag("Player");
        _playerGetHitScript = player.GetComponentInChildren<PlayerGetHit>();
    }

    private void Update()
    {
        if (_playerGetHitScript.IsDead())
        {
            Defeat();
        }
    }

    public void PauseGame()
    {
        if (GameIsPaused)
        {
            ResumeGame();
            return;
        }
        
        GameIsPaused = true;
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
    }

    private void CleanPauseGame()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
    }

    private void CleanResumeGame()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        CleanResumeGame();
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

    public void LoadNewScene(string sceneName)
    {
        ResumeGame();
        SceneManager.LoadScene(sceneName);
    }

    public void Vicotry()
    {
        CleanPauseGame();
        CoinManager.SavePickedCoins();
        _vicotryWindow.SetActive(true);
    }

    private void Defeat()
    {
        CleanPauseGame();
        _defeatWindow.SetActive(true);
    }
}
