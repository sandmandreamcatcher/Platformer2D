using UnityEngine;

public class Coin : MonoBehaviour
{
    public delegate void Collected(int count);
    public event Collected OnCollect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) && collision is CircleCollider2D) 
        {
            Debug.Log("Collected: " + gameObject.name);
            gameObject.SetActive(false);
            OnCollect.Invoke(1);
        }
    }
}