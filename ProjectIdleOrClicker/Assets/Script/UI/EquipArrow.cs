using UnityEngine;

public class EquipArrow : MonoBehaviour
{
    private Player player;
    private EquipmentListUI targetListUI;

    public void Awake()
    {
        GameManager.Instance.OnItemSelected += OnDisplay;
        gameObject.SetActive(false);
    }

    public void SetArrow(Player player, EquipmentListUI equipListUI)
    {
        this.player = player;
        targetListUI = equipListUI;
    }

    private void OnDisplay(bool isOn)
    {
        gameObject.SetActive(isOn);
    }

    public void OnClick()
    {
        player.status.EquipItem(GameManager.Instance.curItem);
        GameManager.Instance.inventory.RemoveItem(GameManager.Instance.curItemIndex);
        GameManager.Instance.ItemSelectEnd();
    }
}