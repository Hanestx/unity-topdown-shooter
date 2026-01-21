using UnityEngine;
using UnityEngine.UI;

public class HudPresenter : MonoBehaviour
{
    [SerializeField] private HealthComponent _playerHealth;
    [SerializeField] private Slider _hpSlider;

    
    private void OnEnable()
    {
        if (_playerHealth != null)
        {
            _playerHealth.OnHealthChanged += OnHealthChanged;
            _playerHealth.OnDied += OnPlayerDied;
        }
    }

    private void OnDisable()
    {
        if (_playerHealth != null)
        {
            _playerHealth.OnHealthChanged -= OnHealthChanged;
            _playerHealth.OnDied -= OnPlayerDied;
        }
    }

    
    private void OnHealthChanged(int current, int max)
    {
        if (_hpSlider == null)
            return;

        _hpSlider.value = max > 0 ? (float)current / max : 0f;
    }

    private void OnPlayerDied()
    {
        Debug.Log("Player died");
    }
}