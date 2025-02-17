using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Options()
    {
        Debug.Log("Options not implemented yet.");
    }

    public void Quit()
    {
        Debug.Log("Quitting game.");
        Application.Quit();
    }
}
