using System;
using UnityEngine;
using UnityEngine.UI;

public class GaugeUI : MonoBehaviour
{
    private Image gaugeBar;
    private Gauge gauge;

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