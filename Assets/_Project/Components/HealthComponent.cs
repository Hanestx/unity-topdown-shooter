using UnityEngine;
using System;

namespace Project.Components
{
    public class HealthComponent : MonoBehaviour
    {
        public int CurrentHealth { get; private set; }
        public event Action<int, int> OnHealthChanged;
        public event Action OnDied;
        
        
        [SerializeField] private int _maxHealth = 100;
        
        
        private void Awake()
        {
            ResetHealth();
        }

        public void TakeDamage(int damage)
        {
            if (CurrentHealth <= 0)
                return;

            CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);
            OnHealthChanged?.Invoke(CurrentHealth, _maxHealth);

            if (CurrentHealth == 0)
                OnDied?.Invoke();
        }

        public void ResetHealth()
        {
            CurrentHealth = _maxHealth;
            OnHealthChanged?.Invoke(CurrentHealth, _maxHealth);
        }
    }
}