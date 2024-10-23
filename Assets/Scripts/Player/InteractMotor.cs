using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMotor : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private Transform _pointInteract;
    private ISelectable _currentSelect;

    void Update()
    {
        Ray ray = new Ray(_pointInteract.transform.position,_pointInteract.transform.forward);

        Debug.DrawRay(_pointInteract.transform.position, _pointInteract.transform.forward * _distance,Color.blue);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance))
        {
            if(hitInfo.collider.TryGetComponent(out ISelectable selectable))
            {
                if (!Equals(_currentSelect, selectable))
                {
                    _currentSelect = selectable;
                    _currentSelect?.Select();
                }
            }
        }
        else
        {
            _currentSelect?.DeSelect();
            _currentSelect = null;
        }
    }
}
