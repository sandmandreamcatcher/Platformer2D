using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinTemplate;

    private List<SpawnPoint> _spawnPoints;

    public delegate void TemplateSet(GameObject templateToSpawn);
    public event TemplateSet ObjectToSpawn;

    private void Awake()
    {
        _spawnPoints = new List<SpawnPoint>(GetComponentsInChildren<SpawnPoint>());
    }

    private void Start()
    {
        ObjectToSpawn?.Invoke(_coinTemplate);
    }
}