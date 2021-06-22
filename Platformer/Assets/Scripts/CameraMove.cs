using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class CameraMove : MonoBehaviour
{
    [SerializeField] private Player _player = null;
    private Transform _cameraPosition;

    void Awake()
    {
        _cameraPosition = GetComponent<Transform>(); 
    }

    void FixedUpdate()
    {
        float xDirection = _player.transform.position.x;
        float yDirection = _player.transform.position.y / 2;
        float zDirection = -1;

        _cameraPosition.position = new Vector3(xDirection, yDirection, zDirection);
    }
}