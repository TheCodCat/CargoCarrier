using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _controller;

    [SerializeField] private bool _isGround;
    [SerializeField] private float _gravity = -9.8f;

    private Vector2 _inputDirection;
    private Vector3 _moveDirection;

    public void InputDirectionMove(InputAction.CallbackContext context)
    {
        _inputDirection = context.ReadValue<Vector2>();
        _moveDirection.x = _inputDirection.x;
        _moveDirection.z = _inputDirection.y;
    }
    private void Update()
    {
        _isGround = _controller.isGrounded;
        if (!_isGround)
        {
            _moveDirection.y += _gravity * Time.deltaTime;
        }
        else
        {
            _moveDirection.y = -1f;
        }
        _controller.Move(transform.TransformDirection(_moveDirection) * _speed * Time.deltaTime);
    }
}
