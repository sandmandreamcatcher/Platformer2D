using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Range(1, 20)] [SerializeField] private float _moveSpeed = 8.6f;
    [Range(0, 80)] [SerializeField] private float _jumpForce = 50f;

    private Player _player;
    private Rigidbody2D _playerBody;
    private const int _moveDirectionRight = 1;
    private const int _moveDirectionLeft = -1;
    private int _currentDirection = 1;

    public float MoveSpeed => _moveSpeed;

    public UnityAction Run;
    public UnityAction Stopped;
    public UnityAction DirectionTurned;

    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
            Move(_moveDirectionRight);
        if (Input.GetKey(KeyCode.A))
            Move(_moveDirectionLeft);
        if (_playerBody.velocity.x == 0)
            Stopped?.Invoke();
    }

    private void Jump()
    {
        if (_player.IsGrounded == false)
            _player.CheckGround();
        else
            _playerBody.velocity = _jumpForce * Vector2.up;
    }

    private void Move(int direction)
    {
        if (_currentDirection != direction)
        {
            _currentDirection = direction;
            DirectionTurned?.Invoke();
        }

        _playerBody.velocity = new Vector2(_moveSpeed * _currentDirection, _playerBody.velocity.y);
        Run?.Invoke();  
    }
}