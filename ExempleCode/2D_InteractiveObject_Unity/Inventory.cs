using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

class Inventory : MonoBehaviour
{
    public UnityEngine.UI.Text TextUi;

    private InventoryPocket<SpeedBoost> speedBoost = new InventoryPocket<SpeedBoost>();
    private InventoryPocket<Bomb> bomb = new InventoryPocket<Bomb>();

    public void AddItem(InventoryObject obj)
    {
        if (obj is SpeedBoost)
        {
            speedBoost.AddItem(obj as SpeedBoost);
        }
        if (obj is Bomb)
        {
            bomb.AddItem(obj as Bomb);
        }

        try
        {
            TextUi.text = "SpeedBoost:" + speedBoost.GetItems().Count()
                + " " + "Bomb:" + bomb.GetItems().Count();
        }
        catch (Exception e)
        {
            TextUi.text = e.Message;
        }
    }
}
