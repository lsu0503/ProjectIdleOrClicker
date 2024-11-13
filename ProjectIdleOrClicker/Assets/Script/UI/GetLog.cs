using System;
using UnityEngine;

public class GetLog : MonoBehaviour
{
    [SerializeField] private GameObject itemIconPrefab;

    private void Awake()
    {
        UIManager.Instance.logUI = this;
    }

    private void Start()
    {
        GameManager.Instance.inventory.OnGetItem += GetItemLogCreation;
    }

    public void GetItemLogCreation(EquipmentObj item)
    {
        GameObject tempObj = Instantiate(itemIconPrefab, this.transform);
        tempObj.AddComponent<AutoDestructionUI>();
        ItemIconUI tempUI = tempObj.GetComponentInChildren<ItemIconUI>();
        tempUI.SetItem(item, ICONPOSITION.INFOMATION, -1);
    }
}
