using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfCoins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _text.SetText(PlayerPrefs.GetInt("Coins").ToString());
    }
}
