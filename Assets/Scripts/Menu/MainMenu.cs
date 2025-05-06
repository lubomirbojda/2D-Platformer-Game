using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _selectLevelScreen;
    [SerializeField] private GameObject _characterSelectScreen;
    [SerializeField] private GameObject _abilitySelectScreen;
    [SerializeField] private GameObject _optionsScreen;
    [SerializeField] private GameObject _resetScreen;
    [SerializeField] private GameObject _controlsScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!PlayerPrefs.HasKey("FirstStartDone"))
        {
            SetDeafultPlayerPrefs();
        }
        
        CleanMenu();
    }

    //Deactivate all menu windows
    private void CleanMenu()
    {
        _selectLevelScreen.SetActive(false);
        _characterSelectScreen.SetActive(false);
        _abilitySelectScreen.SetActive(false);
        _optionsScreen.SetActive(false);
        _resetScreen.SetActive(false);
        _controlsScreen.SetActive(false);
    }

    //Reset player prefs to default ones
    private void SetDeafultPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("FirstStartDone", 1);
        PlayerPrefs.SetInt("SelectedCharacter", 0);
        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("UnlockedWeaponsCount", 0);
        PlayerPrefs.SetFloat("Volume", 1);
    }

    //Reset game stats
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

    //Switch to level scene with given name
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

    public void ControlsOpen()
    {
        _controlsScreen.SetActive(true);
    }

    public void ControlsClose()
    {
        _controlsScreen.SetActive(false);
    }

    //Save selected character to player prefs
    public void SetSelectedCharacter(int charaterIndex)
    {
        PlayerPrefs.SetInt("SelectedCharacter", charaterIndex);
        PlayerPrefs.Save();
    }

    //Quit game
    public void Quit()
    {
        Application.Quit();
    }
}
