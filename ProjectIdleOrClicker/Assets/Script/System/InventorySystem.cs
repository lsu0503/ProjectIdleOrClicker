using System;
using System.Collections.Generic;

public class InventorySystem
{
    public List<EquipmentObj> inventoryList = new List<EquipmentObj>();
    public InventoryUI ui;

    public event Action<EquipmentObj> OnGetItem;
    public event Action<int> OnRemoveItem;
    public event Action<int> OnEnchantItem;

    public void GetItem(EquipmentObj item)
    {
        inventoryList.Add(item);
        OnGetItem?.Invoke(item);
    }

    public void RemoveItem(int index)
    {
        inventoryList.RemoveAt(index);
        OnRemoveItem?.Invoke(index);
    }

    public void EnchantItem(int index)
    {
        inventoryList[index].EnchantEquipment();
        OnEnchantItem?.Invoke(index);
    }
}