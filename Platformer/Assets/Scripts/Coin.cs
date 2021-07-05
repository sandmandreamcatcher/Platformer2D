﻿using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) && collision is CircleCollider2D)
        {
            gameObject.SetActive(false);
        }
    }
}