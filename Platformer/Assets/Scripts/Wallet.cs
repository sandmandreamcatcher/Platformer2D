using UnityEngine;

public class Wallet : MonoBehaviour
{
    private Player _player;
    public int CoinsCollectedCount { get; private set;}

    private void OnEnable()
    {
        _player = GetComponentInParent<Player>();
        _player.CoinCollected += OnCoinCollected;
    }
    
    private void OnDisable()
    {
        _player.CoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected()
    {
        CoinsCollectedCount++;
    }
}