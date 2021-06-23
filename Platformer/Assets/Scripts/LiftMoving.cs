using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMoving : MonoBehaviour
{
    [SerializeField] private Transform _liftStart;
    [SerializeField] private Transform _liftEnd;
    [SerializeField] private Transform _currentLift;
    [SerializeField] private float _pathTime = 4f;
    private Transform _buffer;
    private BoxCollider2D _start;
    private BoxCollider2D _end;
    private BoxCollider2D _current;
    private float _pathRunningTime = 0f;
    private bool _moveForward = true;

    private void Awake()
    {
        _start = gameObject.GetComponent<BoxCollider2D>();
        _end = gameObject.GetComponent<BoxCollider2D>();
        _current = gameObject.GetComponent<BoxCollider2D>();
        _buffer = _currentLift;
    }

    private void Update()
    {
        _pathRunningTime += Time.deltaTime;
        MoveLift();
    }

    private void MoveLift()
    {
        if (_moveForward)
            _currentLift.position = Vector3.Lerp(_buffer.position, _liftEnd.position, _pathRunningTime / _pathTime);

        if (_moveForward == false)
            _currentLift.position = Vector3.Lerp(_buffer.position, _liftStart.position, _pathRunningTime / _pathTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.gameObject.name);
        if (collision.collider.TryGetComponent<StartPoint>(out StartPoint start) == true)
            _moveForward = true;

        if (collision.collider.TryGetComponent<EndPoint>(out EndPoint end) == true)
            _moveForward = false;

        _buffer.position = _currentLift.position;
        _pathRunningTime = 0f;
    }

    //private void OnTriggerEnter2D(Collider2D _current)
    //{
    //    if (_current.isTrigger && _current.TryGetComponent<StartPoint>(out StartPoint start))
    //    {
    //        Debug.Log("Таки старт!");
    //        _moveForward = true;
    //    }
    //    if (_current.isTrigger && _current.TryGetComponent<EndPoint>(out EndPoint end))
    //    {
    //        Debug.Log("Таки финиш!");
    //        _moveForward = false;
    //    }

    //    _buffer.position = _currentLift.position;
    //    _pathRunningTime = 0f;
    //}
}


// Сделал 2 реализации.
// Если использовать Колизию, то следует:
// - убрать Флаг на триггер; 
// - выбрать точки выхода из коллайдера (места где они выйдут - щелкнут триггер)
// - выкрутить время 
// Усли выбрать смену направления по тригеру:
// - проставить Флаг на триггер;
// - точки триггера расставить в местах смены направления
// - выкрутить время
