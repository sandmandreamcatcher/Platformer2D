using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private LayerMask _layerMask = new LayerMask();
    private BoxCollider2D _boxCollider;
    private float _castDistance = -1;

    public bool IsGrounded { get; private set; } = false;

    private void Awake()
    {
        _player = gameObject.GetComponent<Player>();
        _boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        IsGrounded = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.up, _castDistance, _layerMask);

        if (IsGrounded == true)
            Debug.Log("Я стою во все ноги");
        else
            Debug.Log("Я не стою на земле");
    }
}