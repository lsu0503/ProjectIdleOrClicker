using System;
using UnityEngine;
using UnityEngine.UI;

public class GaugeUI : MonoBehaviour
{
    private Image gaugeBar;
    private Gauge gauge;

    private void Awake()
    {
        gaugeBar = GetComponent<Image>();
    }

    public void SetGauge(Gauge gauge)
    {
        this.gauge = gauge;
        gauge.OnChangeEvent += UpdateGaugeBar;
    }

    private void UpdateGaugeBar(float ratio)
    {
        gaugeBar.fillAmount = ratio;
    }
}