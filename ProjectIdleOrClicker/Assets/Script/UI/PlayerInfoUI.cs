using UnityEngine;

public class PlayerInfoUI : MonoBehaviour
{
    private Player player;
    [SerializeField] private GaugeUI healthUI;
    [SerializeField] private GaugeUI ManaUI;

    private void Start()
    {
        player = GameManager.Instance.player;

        healthUI.SetGauge(player.status.health);
        ManaUI.SetGauge(player.status.mana);
    }
}