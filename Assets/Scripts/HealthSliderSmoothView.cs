using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderSmoothView : HealthView
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed = 1.0f;

    private bool _isChangingValue = false;
    private Coroutine _coroutineJob;

    protected override void OnHealthInited(float minValue, float maxValue)
    {
        _slider.minValue = minValue;
        _slider.maxValue = maxValue;
        _slider.value = maxValue;
    }

    protected override void OnHealthChanged(float health)
    {
        if (_isChangingValue)
        {
            StopCoroutine(_coroutineJob);
        }
        _coroutineJob = StartCoroutine(ChangeSliderValue(health));
    }

    private IEnumerator ChangeSliderValue(float newValue)
    {
        _isChangingValue = true;

        float elapsedTime = 0;

        while (_slider.value != newValue)
        {
            Debug.Log($"_slider.value = {_slider.value}");
            Debug.Log($"newValue = {newValue}");
            float newValueStep = Mathf.MoveTowards(
                _slider.value,
                newValue,
                _speed * Time.deltaTime
            );
            _slider.value = newValueStep;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _slider.value = newValue;

        _isChangingValue = false;
    }
}
