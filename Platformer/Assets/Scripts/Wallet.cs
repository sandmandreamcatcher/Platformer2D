using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _coinsCollectToWin;
    private Coin[] _coins = new Coin[] { };
    private List<Coin> _collectedCoins;
    private int _coinsCollected;

    public delegate void GoalsCompleted();
    public event GoalsCompleted OnComplete;

    private void Start()
    {
        _coins = FindObjectsOfType<Coin>();
        _collectedCoins = _coins.ToList();

        foreach (var coin in _coins)
        {
            coin.OnCollect += CoinCollected;
            coin.OnCollect += CheckGoalsCoins;
        }
    }

    private void OnDestroy()
    {
        foreach (var coin in _coins)
        {
            coin.OnCollect -= CoinCollected;
            coin.OnCollect -= CheckGoalsCoins;
        }
    }

    private void CoinCollected(int count)
    {
        _coinsCollected += count;
        for (int i = 0; i < _collectedCoins.Count; i++)
        {
            _collectedCoins.RemoveAt(i);
        }
    }

    private void ShowCoinProgress()
    {
        Debug.Log("Всего: " + _coinsCollected + " монеток");
    }

    private void CheckGoalsCoins(int count)
    {
        ShowCoinProgress();

        if (_coinsCollected >= _coinsCollectToWin)
            OnComplete?.Invoke();
    }
}