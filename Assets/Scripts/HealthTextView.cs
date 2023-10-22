using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthTextView : HealthView
{
    [SerializeField] private TextMeshProUGUI textMeshPro;

    private float _maxValue;

    protected override void OnHealthInited(float minValue, float maxValue)
    {
        _maxValue = maxValue;
        textMeshPro.text = $"{_maxValue}/{_maxValue}";
    }

    protected override void OnHealthChanged(float health)
    {
        textMeshPro.text = $"{health}/{_maxValue}";
    }
}
