using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private LayerMask _layerMask = new LayerMask();
    [SerializeField] private BoxCollider2D _cellingCheckCollider;
    [SerializeField] private BoxCollider2D _floorCheckCollider;
    private float _castDistance = -1;

    public bool IsGrounded { get; private set; }

    private void Awake()
    {
        _player = gameObject.GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        IsGrounded = true;
        Debug.Log("Я стою");
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        IsGrounded = false;
        Debug.Log("Я падаю!");
    }

    public void CheckGround()
    {
        IsGrounded = Physics2D.BoxCast(_floorCheckCollider.bounds.center, _floorCheckCollider.bounds.size, 0f, Vector2.up, _castDistance, _layerMask);
    }
}