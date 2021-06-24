using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private Coin[] _coins;
    private List<Coin> _collectedCoins;
    private int _coinsCollected = 0;

    private void Start()
    {
        _coinsCollected = 0;
        _coins = FindObjectsOfType<Coin>();
        _collectedCoins = _coins.ToList();

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
        for (int i = 0; i < _collectedCoins.Count; i++)
        {
            if (_collectedCoins[i].IsCollected)
            {
                _coinsCollected++;
                _collectedCoins.RemoveAt(i);
                ShowCoinProgress();
            }
        }
    }

   public void ShowCoinProgress()
    {
        Debug.Log("Всего: " + _coinsCollected + " монеток");
    }
}