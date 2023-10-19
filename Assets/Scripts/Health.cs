using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private HealthBarView _healthBarView;
    [SerializeField] private float _healValue = 10;
    [SerializeField] private float _damageValue = 10;

    private float _currentHealth;
    private readonly float _minHealth = 0;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBarView.Init(_minHealth, _maxHealth);
    }

    public void OnHealHealth()
    {
        Debug.Log("OnHealHealth()");

        if (_currentHealth < _maxHealth)
        {
            if (_currentHealth + _healValue > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
            else
            {
                _currentHealth += _healValue;
            }
            _healthBarView.ChangeValue(_currentHealth);
        }

        Debug.Log($"_currentHealth = {_currentHealth}");
    }

    public void OnDamageHealth()
    {
        Debug.Log("OnDamageHealth()");

        if (_currentHealth > _minHealth)
        {
            if (_currentHealth - _damageValue < _minHealth)
            {
                _currentHealth = _minHealth;
            }
            else
            {
                _currentHealth -= _damageValue;
            }
            _healthBarView.ChangeValue(_currentHealth);
        }

        Debug.Log($"_currentHealth = {_currentHealth}");
    }
}
