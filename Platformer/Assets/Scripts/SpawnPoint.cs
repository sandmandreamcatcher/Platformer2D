using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private CoinSpawner _coinSpawner;

    private void OnEnable()
    {
        _coinSpawner = GetComponentInParent<CoinSpawner>();
        _coinSpawner.ObjectToSpawn += ToSpawnTemplate;
    }

    private void OnDisable()
    {
        if (_coinSpawner != null)
            _coinSpawner.ObjectToSpawn -= ToSpawnTemplate;
    }

    private void ToSpawnTemplate(GameObject template)
    {
        Instantiate(template, transform.position, transform.rotation.normalized);
    }
}