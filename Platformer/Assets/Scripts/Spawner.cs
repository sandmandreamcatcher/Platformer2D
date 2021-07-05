using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _templateToSpawn;
    private List<SpawnPoint> _spawnPoints;

    public int SpawnedItems { get; private set; } = 0;
        
    public delegate void TemplateSet(GameObject templateToSpawn);
    public event TemplateSet ObjectRequired;
     
    private void Awake()
    {
        _spawnPoints = new List<SpawnPoint>(GetComponentsInChildren<SpawnPoint>());
       
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            _spawnPoints[i].ItemSpawned += OnItemSpawned;
        }
    }

    private void Start()
    {
        ObjectRequired?.Invoke(_templateToSpawn);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            _spawnPoints[i].ItemSpawned -= OnItemSpawned;
        }
    }

    private void OnItemSpawned()
    {
        SpawnedItems++;
    }
}