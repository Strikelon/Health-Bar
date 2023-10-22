using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderView : HealthView
{
    [SerializeField] private Slider _slider;

    protected override void OnHealthInited(float minValue, float maxValue)
    {
        _slider.minValue = minValue;
        _slider.maxValue = maxValue;
        _slider.value = maxValue;
    }

    protected override void OnHealthChanged(float health)
    {
        _slider.value = health;
    }
}
