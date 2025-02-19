using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject defaultPlayerPrefab;
    //private GameObject PlayerCharacterToSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject characterToSpawn = MainMenu.selectedCharacter;
        Instantiate(characterToSpawn, defaultPlayerPrefab.transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
