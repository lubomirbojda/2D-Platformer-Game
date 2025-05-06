using UnityEngine;

public class SelectionCharacter : MonoBehaviour
{
    [SerializeField] private GameObject _selection;
    [SerializeField] private int _characterIndex;

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
