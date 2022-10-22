using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    private Animator _animator;
    private Rigidbody _rigibody;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigibody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("Jump");
            _rigibody.AddForce(Vector3.up * _jumpForce);
        }
    }
}
