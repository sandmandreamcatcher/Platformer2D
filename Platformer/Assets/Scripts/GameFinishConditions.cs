using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishConditions : MonoBehaviour
{
    private Player _player;
    private Wallet _wallet;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _wallet = GetComponentInChildren<Wallet>();
        _wallet.OnComplete += DeclareWinner;
        _player.OnDeath += DeclareFailure;
    }

    private void OnDestroy()
    {
        _wallet.OnComplete -= DeclareWinner;
        _player.OnDeath -= DeclareFailure;
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
