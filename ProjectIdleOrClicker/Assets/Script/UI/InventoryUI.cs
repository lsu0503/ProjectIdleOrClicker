using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject itemIconPrefab;
    private List<ItemIconUI> itemUIList = new List<ItemIconUI>();
    private InventorySystem inventory;

    private void Awake()
    {
        inventory = GameManager.Instance.inventory;
        inventory.ui = this;

        inventory.OnGetItem += AddItem;
        inventory.OnRemoveItem += RemoveItem;
        inventory.OnEnchantItem += UpdateItem;
    }

    public void AddItem(EquipmentObj item)
    {
        GameObject tempObj = Instantiate(itemIconPrefab, this.transform);
        ItemIconUI tempUI = tempObj.GetComponent<ItemIconUI>();
        tempUI.SetItem(item, ICONPOSITION.IVENTORY, itemUIList.Count);

        itemUIList.Add(tempUI);
    }

    private void RemoveItem(int index)
    {
        GameObject tempObj = itemUIList[index].gameObject;
        itemUIList.RemoveAt(index);
        Destroy(tempObj);
    }

    public void UpdateItem(int index)
    {
        itemUIList[index].UpdateItem();
    }
}
