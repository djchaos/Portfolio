using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class InventoryPocket<O> where O : InventoryObject
{
    private List<O> listItem = new List<O>();

    public void AddItem(O item)
    {
        listItem.Add(item);
    }

    public O[] GetItems()
    {
        return listItem.ToArray();
    }

}
