using UnityEngine;
using UnityEngine.Events;

public class SpawnPoint : MonoBehaviour
{
    private Spawner _spawner;
    public UnityAction ItemSpawned;
    
    private void OnEnable()
    {
        _spawner = GetComponentInParent<Spawner>();
        _spawner.ObjectRequired += OnObjectRequired;
    }

    private void OnDisable()
    {
        if (_spawner != null)
            _spawner.ObjectRequired -= OnObjectRequired;
    }

    private void OnObjectRequired(GameObject template)
    {
        Instantiate(template, transform.position, transform.rotation.normalized);
        ItemSpawned?.Invoke();
    }
}