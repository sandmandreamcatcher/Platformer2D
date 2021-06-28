using UnityEngine;

[RequireComponent(typeof(LayerMask))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask = new LayerMask();
    [SerializeField] private LayerMask _deathLayerMask = new LayerMask();
    [SerializeField] private BoxCollider2D _cellingCheckCollider;
    [SerializeField] private BoxCollider2D _floorCheckCollider;

    private Animator _animator;
    private float _castDistance = -1;

    public bool IsDead { get; private set; }
    public bool IsGrounded { get; private set; }

    public delegate void Dead();
    public event Dead OnDeath;

    public void CheckGround()
    {
        IsGrounded = Physics2D.BoxCast(_floorCheckCollider.bounds.center, _floorCheckCollider.bounds.size, 0f, Vector2.up, _castDistance, _layerMask);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        CheckDeath();
        IsGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        IsGrounded = false;
    }

    private void CheckDeath()
    {
        IsDead =_cellingCheckCollider.IsTouchingLayers(_deathLayerMask) || _floorCheckCollider.IsTouchingLayers(_deathLayerMask);
        if (IsDead)
        {
            OnDeath?.Invoke();
            _animator.SetBool("PlayerDead", true);
        } 
    }
}