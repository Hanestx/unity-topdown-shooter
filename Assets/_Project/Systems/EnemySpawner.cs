using UnityEngine;
using Project.Core.Pool;

namespace Project.Systems
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnRadius = 10f;

        public event System.Action<Enemy> OnEnemySpawned;

        public void SpawnEnemy()
        {
            Vector3 pos = Random.insideUnitSphere * _spawnRadius;
            pos.y = 0f;
            pos += transform.position;

            Enemy enemy = PoolManager.Instance.EnemyFactory.Create(pos);
            OnEnemySpawned?.Invoke(enemy);
        }
    }
}