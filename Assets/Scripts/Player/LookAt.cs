using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAt : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _sensitivity;
    [SerializeField, Range(0, -90)] private float _minY;
    [SerializeField, Range(0, 90)] private float _maxY;
    private float _xRotate;
    private float _yRotate;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        _xRotate = transform.rotation.y;
        _yRotate = _camera.transform.rotation.x;
    }
    public void Look(InputAction.CallbackContext context)
    {
        _xRotate += context.ReadValue<Vector2>().x * _sensitivity;
        _yRotate -= context.ReadValue<Vector2>().y * _sensitivity;

        _yRotate = Mathf.Clamp(_yRotate, _minY, _maxY);

        _camera.transform.localRotation = Quaternion.Euler(_yRotate, 0, 0);
        transform.rotation = Quaternion.Euler(0, _xRotate, 0);
    }
}
