using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinTemplate;

    private List<SpawnPoint> _spawnPoints;

    private void Awake()
    {
        InitSpawners();
        Create();
    }

    private void InitSpawners()
    {
        _spawnPoints = new List<SpawnPoint>(FindObjectsOfType<SpawnPoint>()) { };

        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            _spawnPoints[i].AtachTemplate(_coinTemplate);
        }
    }

    private void Create()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            _spawnPoints[i].SpawnTemplate();
        }
    }
}