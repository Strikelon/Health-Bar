using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _duration = 1.0f;

    private bool _isChangingValue = false;
    private Coroutine _coroutineJob;

    public void Init(float minValue, float maxValue)
    {
        _slider.minValue = minValue;
        _slider.maxValue = maxValue;
        _slider.value = maxValue;
    }

    public void ChangeValue(float value)
    {
        if (!_isChangingValue)
        {
            _coroutineJob = StartCoroutine(ChangeSliderValue(value));
        }
        else
        {
            StopCoroutine(_coroutineJob);
            _coroutineJob = StartCoroutine(ChangeSliderValue(value));
        }
    }

    private IEnumerator ChangeSliderValue(float newValue)
    {
        _isChangingValue = true;

        float elapsedTime = 0;

        while (IsEqual(_slider.value, newValue) == false)
        {
            float roundedValue = Mathf.Abs(newValue - _slider.value) / _duration * Time.deltaTime;
            float newValueStep = Mathf.MoveTowards(
                _slider.value,
                newValue,
                roundedValue
            );
            _slider.value = newValueStep;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _slider.value = newValue;

        _isChangingValue = false;
    }

    private bool IsEqual(float value1, float value2)
    {
        return Mathf.Round(value1) == Mathf.Round(value2);
    }
}