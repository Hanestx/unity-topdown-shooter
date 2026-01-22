using UnityEngine;
using Project.Systems;

namespace Project.Core.Pool
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _bulletPrewarm = 20;

        private ObjectPool<Bullet> _bulletPool;

        public static PoolManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            _bulletPool = new ObjectPool<Bullet>(
                _bulletPrefab,
                _bulletPrewarm,
                transform
            );
        }

        public Bullet SpawnBullet()
        {
            return _bulletPool.Get();
        }

        public void DespawnBullet(Bullet bullet)
        {
            _bulletPool.Return(bullet);
        }
    }
}