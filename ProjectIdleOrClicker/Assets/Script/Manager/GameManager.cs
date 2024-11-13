using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<PlayerStatus> playersData;
    public int money;
    public InventorySystem inventory;

    public EquipmentObj? curItem;
    public int curItemIndex;
    public event Action<bool> OnItemSelected;

    private void Awake()
    {
        playersData = new List<PlayerStatus>();
        money = 0;
        inventory = new InventorySystem();

        curItem = null;
        curItemIndex = -1;
    }

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
