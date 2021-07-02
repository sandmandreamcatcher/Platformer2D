using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Player))]
public class FinishGame : MonoBehaviour
{
    private Player _player;
    private Wallet _wallet;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _wallet = GetComponentInChildren<Wallet>();
        _wallet.CoinsCollected += DeclareWinner;
        _player.Dead += DeclareFailure;
    }

    private void OnDestroy()
    {
        _wallet.CoinsCollected -= DeclareWinner;
        _player.Dead -= DeclareFailure;
    }

    private void DeclareWinner()
    {
        Debug.Log("CONGRATULATIONS! YOU ARE A WINNER!");
        ReloadCurrentScene();
    }

    private void DeclareFailure()
    {
        Debug.Log("YOU ARE DEAD!");
        ReloadCurrentScene();
    }

    private void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
