using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Item _item;

    [SerializeField] private Transform _holderPoint;

    public bool HasSpace => _item == null;

    public Item Get()
    {
        Item itemTemp = _item;
        _item = null;
        return itemTemp;
    }

    public void Take(Item item)
    {
        if (HasSpace == false)
        {
            Debug.LogError("No space");
            return;
        }

        _item = item;
        _item.transform.SetParent(_holderPoint);
        _item.transform.localPosition = Vector3.zero;

        _item.HideMesh();
    }
}
