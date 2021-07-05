using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask = new LayerMask();
    [SerializeField] private LayerMask _deathLayerMask = new LayerMask();
    [SerializeField] private BoxCollider2D _floorCheckCollider;
    [SerializeField] private CircleCollider2D _bodyCollider;

    private float _castDistance = -1;

    public bool IsDead { get; private set; }
    public bool IsGrounded { get; private set; }

    public UnityAction Died;

    public delegate void Fall(bool isGrounded);

    public event Fall Falled;
    public UnityAction CoinCollected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsGrounded == false)
            Falled?.Invoke(false);

        CheckDeath();
        IsGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Falled?.Invoke(true);
        IsGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Coin>(out Coin coin))
            CoinCollected?.Invoke();
    }

    public void CheckGround()
    {
        IsGrounded = Physics2D.BoxCast(_floorCheckCollider.bounds.center, _floorCheckCollider.bounds.size, 0f,
            Vector2.up, _castDistance, _layerMask);
    }

    private void CheckDeath()
    {
        IsDead = _bodyCollider.IsTouchingLayers(_deathLayerMask) ||
                 _floorCheckCollider.IsTouchingLayers(_deathLayerMask);
        if (IsDead)
            Died?.Invoke();
    }
}