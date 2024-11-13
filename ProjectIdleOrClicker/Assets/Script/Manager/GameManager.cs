using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<PlayerStatus> playersData;
    public int money;
    public InventorySystem inventory;

    public EquipmentObj curItem;
    public int curItemIndex;
    public event Action<bool> OnItemSelected;

    public void ItemSelect(EquipmentObj item, int index)
    {
        curItem = item;
        curItemIndex = index;
        OnItemSelected?.Invoke(true);
    }

    public void ItemSelectEnd()
    {
        curItem = null;
        curItemIndex = -1;
        OnItemSelected?.Invoke(false);
    }
}
