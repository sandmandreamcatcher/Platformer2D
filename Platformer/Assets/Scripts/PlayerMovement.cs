using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(1, 20)] [SerializeField] private float _moveSpeed = 8.6f;
    [Range(0, 80)] [SerializeField] private float _jumpForce = 50f;

    private Animator _animator;
    private Player _player;
    private SpriteRenderer _sprite;
    private Rigidbody2D _playerBody;
    private float xVelocity;

    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        xVelocity = 0f;
        _animator.SetBool("IsJumping", false);
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void FixedUpdate()
    {
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
        if (_player.IsGrounded == false)
        {
            _player.CheckGround();
        }
        else
        {
            _playerBody.velocity = _jumpForce * Vector2.up;
            _animator.SetBool("IsJumping", true);
        }
    }
}