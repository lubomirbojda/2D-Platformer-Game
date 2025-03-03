using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static GameObject selectedCharacter;
    [SerializeField] private GameObject warriorPrefab;
    [SerializeField] private GameObject wizardPrefab;
    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void Awake()
    {
    }

    

    public void Play()
    {
        selectedCharacter = wizardPrefab;
        SceneManager.LoadScene("Level1");
    }

    public void Options()
    {
        selectedCharacter = warriorPrefab;
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
