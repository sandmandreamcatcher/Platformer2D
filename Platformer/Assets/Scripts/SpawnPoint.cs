using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Spawner _coinSpawner;

    private void OnEnable()
    {
        _coinSpawner = GetComponentInParent<Spawner>();
        _coinSpawner.ObjectRequired += ToSpawnTemplate;
    }

    private void OnDisable()
    {
        if (_coinSpawner != null)
            _coinSpawner.ObjectRequired -= ToSpawnTemplate;
    }

    private void ToSpawnTemplate(GameObject template)
    {
        Instantiate(template, transform.position, transform.rotation.normalized);
    }
}