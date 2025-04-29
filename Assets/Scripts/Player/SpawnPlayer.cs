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

    private void InstantiatePlayerCharacter()
    {
        switch (PlayerPrefs.GetInt("SelectedCharacter"))
        {
            case 0:
                SpawnPlayerCharacter(_warriorPrefab);
                break;
            case 1:
                SpawnPlayerCharacter(_wizardPrefab);
                break;

        }
    }

    private void SpawnPlayerCharacter(GameObject playerCharacter)
    {
        var character = Instantiate(playerCharacter, _default.transform.position, Quaternion.identity);
        character.SetActive(true);
    }
}
