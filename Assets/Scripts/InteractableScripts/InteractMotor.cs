using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InteractMotor : MonoBehaviour
{
    //Может пригодится
    public static event UnityAction OnGrap;

    [SerializeField] private float _distance;
    [SerializeField] private Transform _pointInteract;
    [SerializeField] private LayerMask _layerInteract;
    [SerializeField] private LayerMask _layerMask;

    private IGrap _grap;
    public IGrap Grap 
    {
        get 
        {
            return _grap;
        }
        set 
        {
            _grap = value;
            OnGrap?.Invoke();
        } 
    }

    private ISelectable _currentSelect;

    void LateUpdate()
    {
        Ray ray = new Ray(_pointInteract.transform.position, _pointInteract.transform.forward);

        Debug.DrawRay(_pointInteract.transform.position, _pointInteract.transform.forward * _distance, Color.blue);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _layerMask))
        {
            //Debug.Log(hitInfo.collider.name);
            if (hitInfo.collider.TryGetComponent(out ISelectable selectable))
            {
                _currentSelect = selectable;
                selectable.Select();
            }
            else
            {
                if (_currentSelect is not null)
                {
                    //Debug.LogError("Деселект");
                    _currentSelect?.DeSelect();
                    _currentSelect = null;
                }
            }
        }
        else
        {
            //Debug.LogError("Деселект");
            if(_currentSelect is not null)
            {
                _currentSelect?.DeSelect();
                _currentSelect = null;
            }
        }
    }

    public void GrapInteract(InputAction.CallbackContext callback)
    {
        if (!callback.performed) return;

        Ray ray = new Ray(_pointInteract.transform.position, _pointInteract.transform.forward);

        Debug.DrawRay(_pointInteract.transform.position, _pointInteract.transform.forward * _distance, Color.blue);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _layerInteract))
        {
            if(hitInfo.collider.TryGetComponent(out IGrap grap))
            {
                if (Grap is not null) return;

                Grap = grap;
                Grap.Grap();
            }
        }
    }
    public void PutInteract(InputAction.CallbackContext callback)
    {
        if (!callback.performed) return;

        Ray ray = new Ray(_pointInteract.transform.position, _pointInteract.transform.forward);

        Debug.DrawRay(_pointInteract.transform.position, _pointInteract.transform.forward * _distance, Color.blue);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _layerInteract))
        {
            if (hitInfo.collider.TryGetComponent(out IPuten puten))
            {
                if(_grap is not null)
                {
                    puten.Put(Grap);
                    Grap?.Grap();
                    Grap = null;
                }
            }
        }
    }
}
