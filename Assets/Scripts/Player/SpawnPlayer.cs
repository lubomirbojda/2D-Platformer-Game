using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject Default_;
    [SerializeField] private GameObject WarriorPrefab_;
    [SerializeField] private GameObject WizardPrefab_;
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
                Instantiate(WarriorPrefab_, Default_.transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(WizardPrefab_, Default_.transform.position, Quaternion.identity);
                break;

        }
    }
}
