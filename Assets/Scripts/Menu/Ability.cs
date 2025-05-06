using TMPro;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private int _abilityIndex;
    [SerializeField] private GameObject _selection;
    [SerializeField] private GameObject _notBoughtButton;
    [SerializeField] private GameObject _priceTextObject;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private int _price;

    private bool _active = false;
    private bool _isBought = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _priceText.SetText("Price: " + _price.ToString());
        if (PlayerPrefs.HasKey("Ability" + _abilityIndex))
        {
            _isBought = true;
            _notBoughtButton.SetActive(false);

            if (PlayerPrefs.GetInt("Ability" + _abilityIndex) == 1)
            {
                SetAbilityActive();
            }
            else
            {
                DeactivateAbility();
            }
        }
    }

    //Unlock ability if player has enough coins
    public void Buy()
    {
        if (PlayerPrefs.GetInt("Coins") >= _price)
        {
            _isBought = true;
            _notBoughtButton.SetActive(false);
            _priceTextObject.SetActive(false);
            DeactivateAbility();
        }
    }

    //Set ability which player clicked on in menu to active one
    public void SetAbilityActive()
    {
        if (!_isBought)
            return;

        if (_active)
        {
            DeactivateAbility();
            _active = false;
            return;
        }
        _selection.SetActive(true);
        PlayerPrefs.SetInt("Ability" + _abilityIndex, 1);
        _active = true;
    }


    //Deactivate ability which player clicked on in menu
    public void DeactivateAbility()
    {
        if (!_isBought)
            return;

        _selection.SetActive(false);
        PlayerPrefs.SetInt("Ability" + _abilityIndex, 0);
    }
}
