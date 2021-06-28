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
        _player.OnDeath += ReloadCurrentScene;
    }

    private void Start()
    {

    }

    private void OnDestroy()
    {
        _wallet.OnComplete -= DeclareWinner;
        _player.OnDeath -= ReloadCurrentScene;
    }

    private void DeclareWinner()
    {
            Debug.Log("CONGRATULATIONS! YOU ARE A WINNER!");
            ReloadCurrentScene();
    }

    private void ReloadCurrentScene()
    {
        Debug.Log("YOU ARE DEAD!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
