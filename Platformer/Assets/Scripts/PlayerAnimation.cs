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
        _player.Dead += PlayDeathAnimation;
        _player.OnAir += PlayJumpAnimation;
        _movement.Run += PlayRunAnimation;
        _movement.Stopped += PlayIdleAnimation;
        _movement.DirectionTurned += FlipPlayerSprite;
    }

    private void OnDestroy()
    {
        _player.Dead -= PlayDeathAnimation;
        _player.OnAir -= PlayJumpAnimation;
        _movement.Run -= PlayRunAnimation;
        _movement.Stopped -= PlayIdleAnimation;
        _movement.DirectionTurned -= FlipPlayerSprite;
    }

    private void PlayDeathAnimation()
    {
        _animator.SetBool("PlayerDead", true);
    }

    private void PlayJumpAnimation(bool isJumping)
    {
        _animator.SetBool("IsJumping", isJumping);
    }

    private void PlayRunAnimation()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_movement.MoveSpeed));
    }

    private void PlayIdleAnimation()
    {
        _animator.SetFloat("Speed", Mathf.Abs(0));
    }

    private void FlipPlayerSprite()
    {
        if (_sprite.flipX)
            _sprite.flipX = false;
        else
            _sprite.flipX = true;
    }
}