using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static List<CoinScript> PickedCoins = new();

    //Add coin to picked coins list
    public static void AddPickedCoin(CoinScript coin)
    {
        PickedCoins.Add(coin);
    }

    //Save all picked coins at successful level complete
    public static void SavePickedCoins()
    {
        foreach (var coin in PickedCoins)
        {
            coin.SaveCoin();
        }
    }
}
