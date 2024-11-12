using System;
using UnityEngine;

public class Gauge
{
    public float max;
    public float current;
    private bool isInitialFull;

    public event Action OnFullEvent;
    public event Action OnEmptyEvent;
    public event Action<float> OnChangeEvent;

    public Gauge(float max, bool isInitialFull)
    {
        this.max = max;
        this.isInitialFull = isInitialFull;

        InitGauge();
    }

    public void InitGauge()
    {
        if(isInitialFull)
            current = max;

        else
            current = 0;
            
        CallEvents();
    }

    public void ChangeGauge(float amount)
    {
        current += amount;
        current = Mathf.Clamp(current, 0, max);

        CallEvents();
    }

    protected void CallEvents()
    {
        if (current >= max)
            OnFullEvent?.Invoke();

        else if (current <= 0)
            OnEmptyEvent?.Invoke();
        
        OnChangeEvent?.Invoke(current / max);
    }
}
