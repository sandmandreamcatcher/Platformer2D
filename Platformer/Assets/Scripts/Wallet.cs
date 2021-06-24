using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Coin[] _coins;
    [SerializeField] private int _coinsCollected = 0;

    private void OnEnable()
    {
        _coins = FindObjectsOfType<Coin>();

        foreach (var coin in _coins)
        {
            coin.Collected += CoinCollected;
        }
    }

    private void OnDisable()
    {
        foreach (var coin in _coins)
        {
            coin.Collected -= CoinCollected;
        }
    }

    private void CoinCollected()
    {
        foreach (var coin in _coins)
        {
            if (coin.IsCollected == false)
            _coinsCollected++;
        }
        Debug.Log("Всего: " + _coinsCollected + " монеток");
    }
}
