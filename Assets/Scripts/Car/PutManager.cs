using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutManager : MonoBehaviour, ISelectable, IPuten
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Material _baseMaterial;
    [SerializeField] private Material _selectableMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMotor player))
        {
            Select();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMotor player))
        {
            DeSelect();
        }
    }

    public void Select()
    {
        _renderer.material = _selectableMaterial;
        //Debug.Log("ί βϋδελÿώρό");
    }

    public void DeSelect()
    {
        _renderer.material = _baseMaterial;
        //Debug.Log("ί νε βϋδελÿώρό");
    }

    public void Put(IGrap grap)
    {
        Debug.Log(grap);
    }

}
