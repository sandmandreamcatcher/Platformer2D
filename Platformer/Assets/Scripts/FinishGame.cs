using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Player))]
public class FinishGame : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private Player _player;
    private Wallet _wallet;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _wallet = GetComponentInChildren<Wallet>();
    }

    private void Start()
    {
        _player.Died += DeclareFailure;
        _player.CoinCollected += CheckGoalsCoins;
    }

    private void OnDestroy()
    {
        _player.Died -= DeclareFailure;
        _player.CoinCollected -= CheckGoalsCoins;
    }

    private void DeclareWinner()
    {
        ReloadCurrentScene();
    }

    private void DeclareFailure()
    {
        ReloadCurrentScene();
    }

    private void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void CheckGoalsCoins()
    {
        if (_wallet.CoinsCollectedCount >= _spawner.SpawnedItems)
            DeclareWinner();
    }
}