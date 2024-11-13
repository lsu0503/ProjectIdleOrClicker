using System;
using TMPro;
using UnityEngine;

public class ItemInfoUI : MonoBehaviour
{
    private EquipmentObj itemData;
    private ICONPOSITION position;
    private int uiId;

    [SerializeField] private ItemIconUI icon;
    [SerializeField] private TextMeshProUGUI[] statusText;
    [SerializeField] private TextMeshProUGUI itemNameText;

    [SerializeField] private GameObject EquipButton;
    [SerializeField] private GameObject UnequipButton;

    public void Awake()
    {
        UIManager.Instance.itemInfoUI = this;
        gameObject.SetActive(false);
    }

    public void OnDisplay(EquipmentObj item, ICONPOSITION position, int index)
    {
        itemData = item;
        this.position = position;
        uiId = index;

        icon.SetItem(item, ICONPOSITION.INFOMATION, -1);
        UpdateUI();

        if (position == ICONPOSITION.IVENTORY)
        {
            EquipButton.SetActive(true);
            UnequipButton.SetActive(false);
        }

        else if (position == ICONPOSITION.EQUIPLIST)
        {
            EquipButton.SetActive(false);
            UnequipButton.SetActive(true);
        }
    }

    public void UpdateUI()
    {
        icon.UpdateItem();
        itemNameText.text = itemData.baseData.name;

        statusText[0].text = itemData.healthMul.ToString();
        statusText[1].text = itemData.defenceMul.ToString();
        statusText[2].text = itemData.attackMul.ToString();
        statusText[3].text = itemData.magicMul.ToString();
        statusText[4].text = itemData.speedMul.ToString();
    }

    public void OnEquipButton()
    {
        GameManager.Instance.ItemSelect(itemData, uiId);
    }

    public void OnUnequipButton()
    {
        int characterIndex = uiId / 100;
        int itemIndex = uiId % 100;

        GameManager.Instance.inventory.GetItem(itemData);
        GameManager.Instance.playersData[characterIndex].UnequipItem(itemIndex);
    }

    public void OnEnchantButton()
    {
        int EnchantCost = (int)(100 * Math.Pow(3, itemData.level));

        if (GameManager.Instance.money > EnchantCost)
        {
            GameManager.Instance.money -= EnchantCost;
            
            if(position == ICONPOSITION.IVENTORY)
            {
                GameManager.Instance.inventory.EnchantItem(uiId);
            }

            else if(position == ICONPOSITION.EQUIPLIST)
            {
                int characterIndex = uiId / 100;
                int itemIndex = uiId % 100;

                itemData.EnchantEquipment();
                GameManager.Instance.playersData[characterIndex].EnchantItem(itemIndex);
            }

            UpdateUI();
        }
    }
}