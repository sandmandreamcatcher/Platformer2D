using UnityEngine;

[RequireComponent(typeof(Player))]
public class CameraMove : MonoBehaviour
{
    [SerializeField] private Player _player = null;
    private Transform _cameraPosition;

    private void Awake()
    {
        _cameraPosition = GetComponent<Transform>(); 
    }

    private void Update()
    {
        float xDirection = _player.transform.position.x;
        float yDirection = _player.transform.position.y / 2;
        float zDirection = -1;

        _cameraPosition.position = new Vector3(xDirection, yDirection, zDirection);
    }
}