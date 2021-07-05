using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement _movement;
    private Animator _animator;
    private Player _player;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _movement = GetComponent<PlayerMovement>();
        _player.Died += OnDied;
        _player.Falled += OnFalled;
        _movement.Run += OnRun;
        _movement.Stopped += OnStopped;
        _movement.DirectionTurned += OnDirectionTurned;
    }

    private void OnDestroy()
    {
        _player.Died -= OnDied;
        _player.Falled -= OnFalled;
        _movement.Run -= OnRun;
        _movement.Stopped -= OnStopped;
        _movement.DirectionTurned -= OnDirectionTurned;
    }

    private void OnDied()
    {
        _animator.SetBool("PlayerDead", true);
    }

    private void OnFalled(bool isJumping)
    {
        _animator.SetBool("IsJumping", isJumping);
    }

    private void OnRun()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_movement.MoveSpeed));
    }

    private void OnStopped()
    {
        _animator.SetFloat("Speed", Mathf.Abs(0));
    }

    private void OnDirectionTurned()
    {
        if (_sprite.flipX)
            _sprite.flipX = false;
        else
            _sprite.flipX = true;
    }
}