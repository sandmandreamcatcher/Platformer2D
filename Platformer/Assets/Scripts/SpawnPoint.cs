using UnityEngine;
using UnityEngine.Events;

public class SpawnPoint : MonoBehaviour
{
    private Spawner _spawner;
    public UnityAction ItemSpawned;
    
    private void OnEnable()
    {
        _spawner = GetComponentInParent<Spawner>();
        _spawner.ObjectRequired += ToSpawnTemplate;
    }

    private void OnDisable()
    {
        if (_spawner != null)
            _spawner.ObjectRequired -= ToSpawnTemplate;
    }

    private void ToSpawnTemplate(GameObject template)
    {
        Instantiate(template, transform.position, transform.rotation.normalized);
        ItemSpawned?.Invoke();
    }
}