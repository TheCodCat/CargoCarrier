using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ISelectable
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Material _baseMaterial;
    [SerializeField] private Material _selectableMaterial;

    private void Start()
    {
        _renderer.material = _baseMaterial;
    }
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
}
