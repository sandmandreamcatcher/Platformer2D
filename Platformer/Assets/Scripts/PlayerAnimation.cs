using UnityEngine;

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
        _player.OnDeath += PlayDeathAnimation;
        _player.OnAir += PlayJumpAnimation;
        _movement.OnRun += PlayRunAnimation;
    }

    private void OnDestroy()
    {
        _player.OnDeath -= PlayDeathAnimation;
        _player.OnAir -= PlayJumpAnimation;
        _movement.OnRun -= PlayRunAnimation;
    }

    private void PlayDeathAnimation()
    {
        _animator.SetBool("PlayerDead", true);
    }

    private void PlayJumpAnimation(bool isJumping)
    {
        _animator.SetBool("IsJumping", isJumping);
    }

    private void PlayRunAnimation(float runSpeed)
    {
        if (runSpeed < 0)
            _sprite.flipX = true;

        if (runSpeed > 0)
            _sprite.flipX = false;

        _animator.SetFloat("Speed", Mathf.Abs(runSpeed));
    }
}