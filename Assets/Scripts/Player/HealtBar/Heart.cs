using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private GameObject _redHeart;
    [SerializeField] private GameObject _heartObject;

    //Remove heart from screen
    public void RemoveHeartFully()
    {
        _heartObject.SetActive(false);
    }

    //Remove first layer of heart, so player can see he lost it
    public void LoseThisHeart()
    {
        _redHeart.SetActive(false);
    }
}
