using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(1, 20)] [SerializeField] private float _moveSpeed = 8.6f;
    [Range(0, 80)] [SerializeField] private float _jumpForce = 50f;
    [SerializeField] private Animator _animator;
    private Player _player;
    private SpriteRenderer _sprite;
    private Rigidbody2D _playerBody;
    private float xVelocity;

    private void Awake()
    {
        _playerBody = transform.GetComponent<Rigidbody2D>();
        _player = gameObject.GetComponent<Player>();
        _animator = gameObject.GetComponent<Animator>();
        _sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        xVelocity = 0f;
    }

    private void FixedUpdate()
    {
        _animator.SetBool("IsJumping", false);
        if (Input.GetKeyDown(KeyCode.Space) && _player.IsGrounded)
            Jump();

        if (Input.GetKey(KeyCode.D))
            xVelocity = _moveSpeed * 1f;

        if (Input.GetKey(KeyCode.A))
            xVelocity = _moveSpeed * -1f;

        if (xVelocity < 0)
            _sprite.flipX = true;

        else
            _sprite.flipX = false;

        _playerBody.velocity = new Vector2(xVelocity, _playerBody.velocity.y);
        _animator.SetFloat("Speed", Mathf.Abs(xVelocity));
    }

    private void Jump()
    {
        _playerBody.velocity = _jumpForce * Vector2.up;
        _animator.SetBool("IsJumping", true);
    }

    //private void Run()
    //{

    //}
}