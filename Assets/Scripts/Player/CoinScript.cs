using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private string CoinID_;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.GetInt("Coin" + CoinID_) == 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CoinManager.AddPickedCoin(this);
            Destroy(gameObject);
        }
    }

    public void SaveCoin()
    {
        PlayerPrefs.SetInt("Coin" + CoinID_, 1);
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
        PlayerPrefs.Save();
    }
}
