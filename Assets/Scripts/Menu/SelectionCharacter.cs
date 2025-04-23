using UnityEngine;

public class SelectionCharacter : MonoBehaviour
{
    [SerializeField] private GameObject Selection_;
    [SerializeField] private int CharacterIndex_;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("SelectedCharacter") == CharacterIndex_)
        {
            Selection_.SetActive(true);
        }
        else
        {
            Selection_.SetActive(false);
        }
    }
}
