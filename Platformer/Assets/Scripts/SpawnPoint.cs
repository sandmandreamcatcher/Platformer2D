using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private CoinSpawner _coinSpawner;

    private void OnEnable()
    {
        _coinSpawner = GetComponentInParent<CoinSpawner>();
        _coinSpawner.TemplateSet += SpawnTemplate;
    }

    private void OnDisable()
    {
        if (_coinSpawner != null)
            _coinSpawner.TemplateSet -= SpawnTemplate;
    }

    private void SpawnTemplate(GameObject template)
    {
        Instantiate(template, transform.position, transform.rotation.normalized);
    }
}