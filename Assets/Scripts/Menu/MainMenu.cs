using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _selectLevelScreen;
    [SerializeField] private GameObject _characterSelectScreen;
    [SerializeField] private GameObject _abilitySelectScreen;
    [SerializeField] private GameObject _optionsScreen;
    [SerializeField] private GameObject _resetScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!PlayerPrefs.HasKey("FirstStartDone"))
        {
            SetDeafultPlayerPrefs();
        }
        
        CleanMenu();
    }

    private void CleanMenu()
    {
        _selectLevelScreen.SetActive(false);
        _characterSelectScreen.SetActive(false);
        _abilitySelectScreen.SetActive(false);
        _optionsScreen.SetActive(false);
        _resetScreen.SetActive(false);
    }

    private void SetDeafultPlayerPrefs()
    {
        PlayerPrefs.SetInt("FirstStartDone", 1);
        PlayerPrefs.SetInt("SelectedCharacter", 0);
        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("UnlockedWeaponsCount", 0);
        PlayerPrefs.SetFloat("Volume", 1);
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        SetDeafultPlayerPrefs();
    }

    public void Play()
    {
        _selectLevelScreen.SetActive(true);
    }

    public void LevelSelectionClose()
    {
        _selectLevelScreen.SetActive(false);
    }

    public void CharacterSelectionButton()
    {
        _characterSelectScreen.SetActive(true);
    }

    public void CharacterSelectionClose()
    {
        _characterSelectScreen.SetActive(false);
    }

    public void AbilitySelectionButton()
    {
        _abilitySelectScreen.SetActive(true);
    }

    public void AbilitySelectionClose()
    {
        _abilitySelectScreen.SetActive(false);
    }

    public void StartLevel(string sceneName)
    {
        CleanMenu();
        CoinManager.PickedCoins.Clear();
        SceneManager.LoadScene(sceneName);
    }

    public void Options()
    {
        _optionsScreen.SetActive(true);
    }

    public void OptionsClose()
    {
        _optionsScreen.SetActive(false);
    }

    public void ResetButtonClick()
    {
        _resetScreen.SetActive(true);
    }

    public void ResetClose()
    {
        _resetScreen.SetActive(false);
    }

    public void SetSelectedCharacter(int charaterIndex)
    {
        PlayerPrefs.SetInt("SelectedCharacter", charaterIndex);
        PlayerPrefs.Save();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
