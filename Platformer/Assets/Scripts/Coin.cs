using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private UnityEvent _collected = new UnityEvent();

    public bool IsCollected { get; private set; }

    public event UnityAction Collected
    {
        add => _collected.AddListener(value);
        remove => _collected.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player)) 
        {
            IsCollected = true;
            _collected.Invoke();
            gameObject.SetActive(false); 
        }
    }   
}