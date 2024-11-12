using System.Collections.Generic;

public class DataManager : Singleton<DataManager>
{
    private Dictionary<int, StatusEffectBase> statusEffectDictionary;

    public void SetStatusEffectDictionary()
    {
        statusEffectDictionary = new Dictionary<int, StatusEffectBase>();

        statusEffectDictionary.Add(0, new DefenceStatusEffect());
        statusEffectDictionary.Add(1, new AttackStatusEffect());
        statusEffectDictionary.Add(10, new DamageStatusEffect());
        statusEffectDictionary.Add(11, new HealingStatusEffect());
    }
}