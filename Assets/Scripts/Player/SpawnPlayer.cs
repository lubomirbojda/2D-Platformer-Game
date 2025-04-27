using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _default;
    [SerializeField] private GameObject _warriorPrefab;
    [SerializeField] private GameObject _wizardPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InstantiatePlayerCharacter();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstantiatePlayerCharacter()
    {
        switch (PlayerPrefs.GetInt("SelectedCharacter"))
        {
            case 0:
                Instantiate(_warriorPrefab, _default.transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(_wizardPrefab, _default.transform.position, Quaternion.identity);
                break;

        }
    }
}
