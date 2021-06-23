using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMoving : MonoBehaviour
{
    [SerializeField] private Transform _liftStart;
    [SerializeField] private Transform _liftEnd;
    [SerializeField] private Transform _currentLift;
    [SerializeField] private float _pathTime = 3f;
    [SerializeField] private float _pathRunningTime = 0f;
    [SerializeField] private bool _moveForward = true;
    [SerializeField] private Collider2D _start;
    [SerializeField] private Collider2D _end;
    [SerializeField] private Collider2D _current;

    private void Update()
    {
        _pathRunningTime += Time.deltaTime;
        MoveLift();
    }

    private void MoveLift()
    {
        if (_moveForward)
        {
            _currentLift.position = Vector3.Lerp(_liftStart.position, _liftEnd.position, _pathRunningTime / _pathTime);
        }
        else
        {
            _currentLift.position = Vector3.Lerp(_liftEnd.position, _liftStart.position, _pathRunningTime / _pathTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D _current)
    {
        if (_moveForward)
        {
            _moveForward = false;
            Debug.Log("Move Forward finished!");
        }
        else
        {
            _moveForward = true;
            Debug.Log("Back move finished!");
        }
    }

    //private void OnTriggerEnter2D(Collider2D _current)
    //{
    //    if (_current == _start)
    //        _moveForward = false;
    //    else if (_current == _end)
    //        _moveForward = true;

    //    _pathRunningTime = 0f;
    //    MoveLift();
    //}
}