using UnityEngine;
using Project.Core.Pool;

namespace Project.Systems
{
    public class EnemyFactory
    {
        private readonly PoolManager _pool;

        public EnemyFactory(PoolManager pool)
        {
            _pool = pool;
        }

        public Enemy Create(Vector3 position)
        {
            Enemy enemy = _pool.SpawnEnemy();
            enemy.transform.position = position;
            enemy.transform.rotation = Quaternion.identity;
            return enemy;
        }
    }
}