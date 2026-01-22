using System;
using UnityEngine;

namespace Project.Components
{
    public class HealthComponent : MonoBehaviour
    {
        public int CurrentHp { get; private set; }
        public int MaxHp => _maxHp;


        [SerializeField] private int _maxHp = 100;


        public event Action<int, int> OnHealthChanged; // current, max
        public event Action OnDied;


        private void Awake()
        {
            CurrentHp = _maxHp;
            OnHealthChanged?.Invoke(CurrentHp, _maxHp);
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                TakeDamage(10);
            }
        }
#endif


        public void TakeDamage(int damage)
        {
            if (damage <= 0 || CurrentHp <= 0)
                return;

            CurrentHp = Mathf.Max(0, CurrentHp - damage);
            OnHealthChanged?.Invoke(CurrentHp, _maxHp);

            if (CurrentHp == 0)
                OnDied?.Invoke();
        }

        public void Heal(int amount)
        {
            if (amount <= 0 || CurrentHp <= 0)
                return;

            CurrentHp = Mathf.Min(_maxHp, CurrentHp + amount);
            OnHealthChanged?.Invoke(CurrentHp, _maxHp);
        }
    }
}