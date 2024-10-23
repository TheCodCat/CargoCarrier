using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ISelectable, IGrap
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Material _baseMaterial;
    [SerializeField] private Material _selectableMaterial;
    [SerializeField] private Collider _collider;
    public void Select()
    {
        //Debug.Log("ί βϋδελÿώρό");
        _renderer.material = _selectableMaterial;
    }

    public void DeSelect()
    {
        //Debug.Log("ί νε βϋδελÿώρό");
        _renderer.material = _baseMaterial;
    }

    public void Grap()
    {
        _collider.enabled = false;
        _renderer.enabled = false;
    }
}
