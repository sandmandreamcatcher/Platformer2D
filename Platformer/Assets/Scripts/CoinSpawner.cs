using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinTemplate;

    private List<SpawnPoint> _spawnPoints;
    private int _objectSent = 1;

    public delegate void SetTemplate(GameObject templateToSpawn);
    public event SetTemplate TemplateSet;

    private void Awake()
    {
        InitSpawners();
    }

    private void Start()
    {
        if (_objectSent > 0)
        {
            TemplateSet?.Invoke(_coinTemplate);
            _objectSent -= 1;
            Debug.Log("Я сделаль");
        }
    }

    private void InitSpawners()
    {
        _spawnPoints = new List<SpawnPoint>(GetComponentsInChildren<SpawnPoint>()) { };
    }
}