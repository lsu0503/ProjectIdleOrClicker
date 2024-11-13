using System.Collections.Generic;
using UnityEngine;

public class EquipmentListUI: MonoBehaviour
{
    private int characterIndex;
    private Player player;
    [SerializeField] private GameObject ItemIconPrefab;
    public List<ItemIconUI> itemUIList = new List<ItemIconUI>();

    public void SetUI(int characterIndex, Player character)
    {
        this.characterIndex = characterIndex;
        player = character;

        player.status.OnEquipEvent += AddItem;
        player.status.OnUnequipEvent += RemoveItem;
        player.status.OnEnchantEvent += UpdateItem;
    }

    private void Status_OnUnequipEvent(int obj)
    {
        throw new System.NotImplementedException();
    }

    public void AddItem(EquipmentObj equipItem)
    {
        GameObject tempObj = Instantiate(ItemIconPrefab, this.transform);
        ItemIconUI tempUI = tempObj.GetComponent<ItemIconUI>();
        tempUI.SetItem(equipItem, ICONPOSITION.EQUIPLIST, itemUIList.Count + (100 * characterIndex));

        itemUIList.Add(tempUI);
    }

    public void RemoveItem(int index)
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
