using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ISelectable, IGrap
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Material _baseMaterial;
    [SerializeField] private Material _selectableMaterial;
    [SerializeField] private Collider _collider;
    [SerializeField] private bool _isGrap;
    [SerializeField] private bool _isPut = true;
    public void Select()
    {
        //Debug.Log("ί βϋδελÿώρό");
        if (_isPut) return;

        _renderer.material = _selectableMaterial;
    }

    public void DeSelect()
    {
        //Debug.Log("ί νε βϋδελÿώρό");
        _renderer.material = _baseMaterial;
    }

    public void Grap()
    {
        if (!_isPut)
        {
            _isGrap = true;
            _collider.enabled = false;
            _renderer.enabled = false;
        }
        else
        {
            _isGrap = false;
            _collider.enabled = true;
            _renderer.enabled = true;
        }
    }

    public void Put(Vector3 vector3)
    {
        gameObject.transform.position = vector3;
        _isPut = true;
    }
}
