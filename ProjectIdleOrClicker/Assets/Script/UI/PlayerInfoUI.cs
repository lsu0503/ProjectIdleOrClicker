using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    private Player player;
    private int index;
    [SerializeField] private GaugeUI healthUI;
    [SerializeField] private GaugeUI ManaUI;
    [SerializeField] private Image characterIcon;
    public EquipmentListUI equipListUI;
    public EquipArrow arrowUI;

    private void Awake()
    {
        equipListUI = GetComponentInChildren<EquipmentListUI>();
    }

    public void SetCharacter(Player playerCharacter)
    {
        player = playerCharacter;
        index = GameManager.Instance.playersData.FindIndex(id => ReferenceEquals(id, player.status));

        healthUI.SetGauge(player.status.HealthGauge);
        ManaUI.SetGauge(player.status.ManaGauge);
        characterIcon.sprite = player.status.data.image;
        equipListUI.SetUI(index, player);
        arrowUI.SetArrow(player, equipListUI);
    }
}
