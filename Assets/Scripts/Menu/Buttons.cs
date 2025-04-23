using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject SelectLevelScreen_;
    [SerializeField] private GameObject CharacterSelectScreen_;
    [SerializeField] private GameObject AbilitySelectScreen_;
    [SerializeField] private GameObject OptionsScreen_;
    [SerializeField] private GameObject ResetScreen_;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!PlayerPrefs.HasKey("FirstStartDone"))
        {
            SetDeafultPlayerPrefs();
        }
        
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
        SelectLevelScreen_.SetActive(true);
    }

    public void LevelSelectionClose()
    {
        SelectLevelScreen_.SetActive(false);
    }

    public void CharacterSelectionButton()
    {
        CharacterSelectScreen_.SetActive(true);
    }

    public void CharacterSelectionClose()
    {
        CharacterSelectScreen_.SetActive(false);
    }

    public void AbilitySelectionButton()
    {
        AbilitySelectScreen_.SetActive(true);
    }

    public void AbilitySelectionClose()
    {
        AbilitySelectScreen_.SetActive(false);
    }

    public void Level1Button()
    {
        CoinManager.pickedCoins.Clear();
        SceneManager.LoadScene("Level1");
    }

    public void Options()
    {
        OptionsScreen_.SetActive(true);
    }

    public void OptionsClose()
    {
        OptionsScreen_.SetActive(false);
    }

    public void ResetButtonClick()
    {
        ResetScreen_.SetActive(true);
    }

    public void ResetClose()
    {
        ResetScreen_.SetActive(false);
    }

    public void SetSelectedCharacter(int charaterIndex)
    {
        PlayerPrefs.SetInt("SelectedCharacter", charaterIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
