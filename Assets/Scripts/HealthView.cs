using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.HealthInited += OnHealthInited;
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthInited -= OnHealthInited;
        _health.HealthChanged -= OnHealthChanged;
    }

    protected abstract void OnHealthInited(float minValue, float maxValue);

    protected abstract void OnHealthChanged(float health);
}
