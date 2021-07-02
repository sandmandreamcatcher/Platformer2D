using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _templateToSpawn;

    private List<SpawnPoint> _spawnPoints;

    public delegate void TemplateSet(GameObject templateToSpawn);
    public event TemplateSet ObjectRequired;

    private void Awake()
    {
        _spawnPoints = new List<SpawnPoint>(GetComponentsInChildren<SpawnPoint>());
    }

    private void Start()
    {
        ObjectRequired?.Invoke(_templateToSpawn);
    }
}