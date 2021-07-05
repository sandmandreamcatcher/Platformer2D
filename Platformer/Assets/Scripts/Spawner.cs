using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _templateToSpawn;
    private List<SpawnPoint> _spawnPoints;

    public int SpawnedItems { get; private set; }
     
    private void Awake()
    {
        _spawnPoints = new List<SpawnPoint>(GetComponentsInChildren<SpawnPoint>());
        SpawnItems();
    }

    private void SpawnItems()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            Instantiate(_templateToSpawn, _spawnPoints[i].transform.position, _spawnPoints[i].transform.rotation.normalized);
            SpawnedItems++;
        }
    }
}