using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    
    private Animator _animator;
    private Rigidbody _rigibody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigibody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(OrtizAnimationController.Params.Jump);
            _rigibody.AddForce(Vector3.up * _jumpForce);
        }
    }
}