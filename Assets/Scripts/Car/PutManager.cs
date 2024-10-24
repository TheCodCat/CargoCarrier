using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PutManager : MonoBehaviour, ISelectable, IPuten
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Material _baseMaterial;
    [SerializeField] private Material _selectableMaterial;
    [SerializeField] private PutPoint[] _putPoints;

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
        PutPoint freePosition = _putPoints.FirstOrDefault(x => x.IsFree);
        if (freePosition is null) return;

        Debug.Log(freePosition);
        freePosition.IsFree = false;
        grap.Put(freePosition.PutPosition.position);
    }

}
[System.Serializable]
public class PutPoint
{
    public bool IsFree = true;
    public Transform PutPosition;
    public IGrap Grap;
}
