using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _camera;

    private float _smoothMoveY = 2f;
    private float _cameraOffsetZ = -1f;

    private void Update()
    {
        _camera.position = new Vector3(_player.transform.position.x, _player.transform.position.y / _smoothMoveY, _cameraOffsetZ);
    }
}