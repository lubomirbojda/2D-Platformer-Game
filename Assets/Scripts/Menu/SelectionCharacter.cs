using UnityEngine;

public class SelectionCharacter : MonoBehaviour
{
    [SerializeField] private GameObject _selection;
    [SerializeField] private int _characterIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("SelectedCharacter") == _characterIndex)
        {
            _selection.SetActive(true);
        }
        else
        {
            _selection.SetActive(false);
        }
    }
}
