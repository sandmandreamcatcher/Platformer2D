using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _coinsCollectToWin;
    private Coin[] _coins = new Coin[] { };
    private List<Coin> _collectedCoins;
    private int _coinsCollected;

    public UnityAction CoinsCollected;

    private void Start()
    {
        _coins = FindObjectsOfType<Coin>();
        _collectedCoins = _coins.ToList();

        foreach (var coin in _coins)
        {
            coin.Collected += CoinCollected;
            coin.Collected += CheckGoalsCoins;
        }
    }

    private void OnDestroy()
    {
        foreach (var coin in _coins)
        {
            coin.Collected -= CoinCollected;
            coin.Collected -= CheckGoalsCoins;
        }
    }

    private void CoinCollected()
    {
        _coinsCollected ++;

        for (int i = 0; i < _collectedCoins.Count; i++)
        {
            _collectedCoins.RemoveAt(i);
        }
    }

    private void CheckGoalsCoins()
    {
        ShowCoinProgress();

        if (_coinsCollected >= _coinsCollectToWin)
            CoinsCollected?.Invoke();
    }

    private void ShowCoinProgress()
    {
        Debug.Log("Всего: " + _coinsCollected + " монеток");
    }
}