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
    [SerializeField] private BoxCollider2D _start;
    [SerializeField] private BoxCollider2D _end;
    [SerializeField] private BoxCollider2D _current;


    private void Awake()
    {
        _current = gameObject.GetComponent<BoxCollider2D>();
    }

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
        if (!_moveForward)
        {
            _currentLift.position = Vector3.Lerp(_liftEnd.position, _liftStart.position, _pathRunningTime / _pathTime);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.collider.gameObject.name);
        if (collision.otherCollider.TryGetComponent<StartPoint>(out StartPoint start))
        {
            Debug.Log("Move finished!");
            ChangeDirection();
            return;
        }

        if (collision.collider.TryGetComponent<EndPoint>(out EndPoint end))
        {
            ChangeDirection();
            Debug.Log("Move finished!");
            return;
        }
    }

    private void ChangeDirection()
    {
        _pathRunningTime = 0f;
        if (_moveForward)
            _moveForward = false;
        else
            _moveForward = true;
    }

    //private void OnTriggerEnter2D(Collider2D _current)
    //{
    //if (TryGetComponent<BoxCollider2D>(out BoxCollider2D end) && end == _end)
    //{
    //    Debug.Log("MovePIDOR");
    //    _moveForward = false;
    //    _pathRunningTime = 0f;
    //    return;
    //}

    //if (TryGetComponent<BoxCollider2D>(out BoxCollider2D start) && start == _start)
    //{
    //    Debug.Log("MovePIDOR");
    //    _moveForward = true;
    //    _pathRunningTime = 0f;
    //    Debug.Log("Move finished!");
    //    return;
    //}
    //}
}