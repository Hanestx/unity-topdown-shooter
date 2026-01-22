using UnityEngine;
using Project.Components;
using Project.Core.Pool;

namespace Project.Systems
{
    [RequireComponent(typeof(HealthComponent))]
    public class Enemy : MonoBehaviour, IPoolable
    {
        private HealthComponent _health;
        
        private void Awake()
        {
            _health = GetComponent<HealthComponent>();
        }

        public void OnSpawned()
        {
            _health.ResetHealth();
            _health.OnDied += OnDied;
        }

        public void OnDespawned()
        {
            _health.OnDied -= OnDied;
        }

        private void OnDied()
        {
            PoolManager.Instance.DespawnEnemy(this);
        }
    }
}