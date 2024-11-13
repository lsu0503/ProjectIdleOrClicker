using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public PlayerCharacterList playerCharacterListUI;
    public GaugeUI bossHealthBar;
    public ItemInfoUI itemInfoUI;
    public GetLog logUI;
    public MoneyUI moneyUI;
}