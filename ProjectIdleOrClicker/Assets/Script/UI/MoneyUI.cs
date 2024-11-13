using System;
using TMPro;
using UnityEngine;

public class MoneyUI: MonoBehaviour
{
    private TextMeshProUGUI moneyText;

    private void Awake()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
        UIManager.Instance.moneyUI = this;
    }

    private void Start()
    {
        GameManager.Instance.OnMoneyChanged += UpdateMoney;
        UpdateMoney();
    }

    private void UpdateMoney()
    {
        moneyText.text = GameManager.Instance.money.ToString();
    }
}