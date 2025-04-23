using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static List<CoinScript> pickedCoins = new List<CoinScript>();

    public static void AddPickedCoin(CoinScript coin)
    {
        pickedCoins.Add(coin);
        Debug.Log(pickedCoins.Count);
    }

    public static void SavePickedCoins()
    {
        foreach (var coin in pickedCoins)
        {
            coin.SaveCoin();
        }
    }
}
