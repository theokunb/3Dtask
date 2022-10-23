using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _accelerationTime;
    
    private Animator _animator;
    private float _idleSpeed;
    private float _defaultAcceleration;
    private float _walkElapsedTime;
    private float _runElapsedTime;
    private float _currentRunSpeed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _idleSpeed = 0;
        _defaultAcceleration = 1;
        _currentRunSpeed = _defaultAcceleration;
        _walkElapsedTime = 0;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            _animator.SetFloat(OrtizAnimationController.Params.Speed, _speed);
            _walkElapsedTime += Time.deltaTime;

            if(_walkElapsedTime > _accelerationTime)
            {
                _walkElapsedTime = _accelerationTime;
            }

            transform.position += transform.forward * (_speed * _walkElapsedTime / _accelerationTime) * _currentRunSpeed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _animator.SetBool(OrtizAnimationController.Params.BackWalk, true);
            _animator.SetFloat(OrtizAnimationController.Params.Speed, _speed);
            _walkElapsedTime += Time.deltaTime;

            if(_walkElapsedTime > _accelerationTime)
            {
                _walkElapsedTime = _accelerationTime;
            }

            transform.position -= transform.forward * (_speed * _walkElapsedTime / _accelerationTime) * Time.deltaTime;
        }
        else
        {
            _walkElapsedTime = 0;
            _animator.SetBool(OrtizAnimationController.Params.BackWalk, false);
            _animator.SetFloat(OrtizAnimationController.Params.Speed, _idleSpeed);
        }


        if(Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool(OrtizAnimationController.Params.Run, true);
            _runElapsedTime += Time.deltaTime;

            if(_runElapsedTime > _accelerationTime)
            {
                _runElapsedTime = _accelerationTime;
            }

            _currentRunSpeed = _runElapsedTime / _accelerationTime * _runSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            _animator.SetBool(OrtizAnimationController.Params.Run, false);
            _runElapsedTime = 0;
            _currentRunSpeed = _defaultAcceleration;
        }
    }
}