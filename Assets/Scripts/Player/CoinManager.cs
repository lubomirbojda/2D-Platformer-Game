using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static List<CoinScript> PickedCoins = new();

    public static void AddPickedCoin(CoinScript coin)
    {
        PickedCoins.Add(coin);
    }

    public static void SavePickedCoins()
    {
        foreach (var coin in PickedCoins)
        {
            coin.SaveCoin();
        }
    }
}
