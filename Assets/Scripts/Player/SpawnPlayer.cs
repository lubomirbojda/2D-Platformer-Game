using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _default;
    [SerializeField] private GameObject _warriorPrefab;
    [SerializeField] private GameObject _wizardPrefab;

    private void Awake()
    {
        InstantiatePlayerCharacter();
    }

    private void InstantiatePlayerCharacter()
    {
        switch (PlayerPrefs.GetInt("SelectedCharacter"))
        {
            case 0:
                SpawnPlayerCharacter(_warriorPrefab, 2);
                break;
            case 1:
                SpawnPlayerCharacter(_wizardPrefab, 1);
                break;

        }
    }

    private void SpawnPlayerCharacter(GameObject playerCharacter, int damage)
    {
        var character = Instantiate(playerCharacter, _default.transform.position, Quaternion.identity);
        character.SetActive(true);
        PlayerPrefs.SetInt("PlayerDamage", damage);
    }
}
