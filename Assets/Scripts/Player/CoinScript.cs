using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private string _coinID;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _pickCoinClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.GetInt("Coin" + _coinID) == 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioPlay.PlayAudioClip(_audioSource, _pickCoinClip);
            CoinManager.AddPickedCoin(this);
            Destroy(gameObject);
        }
    }

    public void SaveCoin()
    {
        PlayerPrefs.SetInt("Coin" + _coinID, 1);
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
        PlayerPrefs.Save();
    }
}
