using UnityEngine;
using Project.Components;
using Project.Core.Pool;

namespace Project.Systems
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        [SerializeField] private float _speed = 12f;
        [SerializeField] private float _lifeTime = 2f;
        [SerializeField] private int _damage = 10;

        private Vector3 _direction;
        private float _timer;

        public void Init(Vector3 direction)
        {
            _direction = direction;
            _timer = _lifeTime;
        }

        private void Update()
        {
            transform.position += _direction * (_speed * Time.deltaTime);

            _timer -= Time.deltaTime;
            if (_timer <= 0f)
                PoolManager.Instance.DespawnBullet(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HealthComponent health))
            {
                health.TakeDamage(_damage);
                PoolManager.Instance.DespawnBullet(this);
            }
        }

        public void OnSpawned()
        {
            _timer = _lifeTime;
        }

        public void OnDespawned()
        {
        }
    }
}