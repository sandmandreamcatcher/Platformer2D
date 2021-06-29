using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinTemplate;

    private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();

    public delegate void SetTemplate(GameObject templateToSpawn);
    public event SetTemplate TemplateSet;

    private void Awake()
    {
        _spawnPoints = new List<SpawnPoint>(GetComponentsInChildren<SpawnPoint>());
    }

    private void Start()
    {
        TemplateSet?.Invoke(_coinTemplate);
    }
}