using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(1, 20)] [SerializeField] private float _moveSpeed = 8.6f;
    [Range(0, 80)] [SerializeField] private float _jumpForce = 50f;

    private Player _player;
    private Rigidbody2D _playerBody;
    private float xVelocity;

    public delegate void Run(float runSpeed);
    public event Run OnRun;

    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        xVelocity = 0f;

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
            xVelocity = _moveSpeed * 1f;

        if (Input.GetKey(KeyCode.A))
            xVelocity = _moveSpeed * -1f;

        if (xVelocity != 0)
            OnRun?.Invoke(Mathf.Clamp(xVelocity, -1f, 1f));

        if (xVelocity == 0 && Input.anyKey == false)
            OnRun?.Invoke(0);

        _playerBody.velocity = new Vector2(xVelocity, _playerBody.velocity.y);
    }

    private void Jump()
    {
        if (_player.IsGrounded == false)
            _player.CheckGround();
        else
            _playerBody.velocity = _jumpForce * Vector2.up;
    }
}