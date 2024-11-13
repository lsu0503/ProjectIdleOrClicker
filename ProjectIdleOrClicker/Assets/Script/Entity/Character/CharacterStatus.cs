using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterStatus : MonoBehaviour
{
    [Header("Character Status")]
    public Gauge HealthGauge;

    public float health;
    public float defence;
    public float attack;

    protected List<StatusEffectBase> StatusEffectList = new List<StatusEffectBase>();
    public event Action<float> OnTimePassedEvent;

    protected virtual void Awake()
    {
        HealthGauge = new Gauge(health, true);
    }

    protected virtual void FixedUpdate()
    {
        CallTimePassedEvent(Time.deltaTime);
    }

    public void GetDamage(float damage)
    {
        float finalDamage = damage / defence;

        HealthGauge.ChangeGauge(-finalDamage);
    }

    public void GetHeal(float amount)
    {
        HealthGauge.ChangeGauge(amount);
    }

    private void CallTimePassedEvent(float deltaTime)
    {
        OnTimePassedEvent?.Invoke(deltaTime);
    }

    public void GetStatusEffect(StatusEffectBase effect)
    {
        StatusEffectList.Add(effect);
        effect.OnEffectStart(this);
    }

    public void StatusOvered(StatusEffectBase effect)
    {
        int index = StatusEffectList.FindIndex(idx => ReferenceEquals(idx, effect));

        if (index == -1) return;

        StatusEffectList.RemoveAt(index);
    }
}
