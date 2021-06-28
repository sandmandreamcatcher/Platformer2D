using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Transform))]
public class CameraMove : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _camera;

    private void Update()
    {
        _camera.position = new Vector3(_player.transform.position.x, _player.transform.position.y / 2, -1);
    }
}