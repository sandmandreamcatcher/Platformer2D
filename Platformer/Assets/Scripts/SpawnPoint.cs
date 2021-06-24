using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _template;

    public void SpawnTemplate()
    {
        Instantiate(_template, transform.position, transform.rotation.normalized);
    }

    public void AtachTemplate(GameObject template)
    {
        _template = template;
    }
}