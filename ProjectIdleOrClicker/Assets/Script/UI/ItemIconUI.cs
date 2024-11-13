using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ICONPOSITION
{
    IVENTORY,
    EQUIPLIST,
    INFOMATION
}

public class ItemIconUI : MonoBehaviour
{
    private EquipmentObj itemData;
    [SerializeField] private Image ItemImg;
    [SerializeField] private TextMeshProUGUI levelText;
    private ICONPOSITION position;
    private int index;

    public void SetItem(EquipmentObj item, ICONPOSITION position, int index)
    {
        itemData = item;
        ItemImg.sprite = itemData.baseData.ItemImage;
        levelText.text = itemData.level.ToString();

        this.position = position;

        this.index = index;
    }

    public void UpdateItem()
    {
        levelText.text = itemData.level.ToString();
    }

    public void OnClick()
    {
        if (position != ICONPOSITION.INFOMATION)
            UIManager.Instance.itemInfoUI.OnDisplay(itemData, position, index);
    }
}
