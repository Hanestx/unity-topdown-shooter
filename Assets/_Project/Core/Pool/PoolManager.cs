using UnityEngine;
using Project.Systems;

namespace Project.Core.Pool
{
    public class PoolManager : MonoBehaviour
    {
        [Header("Bullet Pool")]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _bulletPrewarm = 20;

        [Header("Enemy Pool")]
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private int _enemyPrewarm = 10;

        [Header("Runtime Roots")]
        [SerializeField] private Transform _enemiesRoot;
        [SerializeField] private Transform _projectilesRoot;

        private ObjectPool<Bullet> _bulletPool;
        private ObjectPool<Enemy> _enemyPool;

        public static PoolManager Instance { get; private set; }
        public EnemyFactory EnemyFactory { get; private set; }

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
                _projectilesRoot
            );

            _enemyPool = new ObjectPool<Enemy>(
                _enemyPrefab,
                _enemyPrewarm,
                _enemiesRoot
            );

            EnemyFactory = new EnemyFactory(this);
        }

        public Bullet SpawnBullet()
        {
            return _bulletPool.Get();
        }

        public void DespawnBullet(Bullet bullet)
        {
            _bulletPool.Return(bullet);
        }

        public Enemy SpawnEnemy()
        {
            return _enemyPool.Get();
        }

        public void DespawnEnemy(Enemy enemy)
        {
            _enemyPool.Return(enemy);
        }
    }
}