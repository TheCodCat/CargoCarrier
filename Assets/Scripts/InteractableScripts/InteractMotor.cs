using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractMotor : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private Transform _pointInteract;
    [SerializeField] private LayerMask _layerInteract;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private IGrap _grap;

    private ISelectable _currentSelect;

    /*void Update()
    {
        Ray ray = new Ray(_pointInteract.transform.position, _pointInteract.transform.forward);

        Debug.DrawRay(_pointInteract.transform.position, _pointInteract.transform.forward * _distance, Color.blue);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _layerMask))
        {
            Debug.Log(hitInfo.collider.name);
            if (hitInfo.collider.TryGetComponent(out ISelectable selectable))
            {
                if (!selectable.Equals(_currentSelect))
                {
                    _currentSelect = selectable;
                    selectable.Select();
                }
                else
                {
                    Debug.LogError("Деселект");
                    _currentSelect.DeSelect();
                    _currentSelect = null;
                }
            }
        }
        else
        {
            Debug.LogError("Деселект");
            _currentSelect?.DeSelect();
            _currentSelect = null;
        }
    }*/

    public void PutInteract(InputAction.CallbackContext callback)
    {
        if (!callback.performed) return;

        Ray ray = new Ray(_pointInteract.transform.position, _pointInteract.transform.forward);

        Debug.DrawRay(_pointInteract.transform.position, _pointInteract.transform.forward * _distance, Color.blue);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _layerInteract))
        {
            if(hitInfo.collider.TryGetComponent(out IGrap grap))
            {
                _grap = grap;
                _grap.Grap();
            }
        }
    }
    public void GrapInteract(InputAction.CallbackContext callback)
    {
        if (!callback.performed) return;
    }
}
