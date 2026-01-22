using UnityEngine;
using Project.Core.Pool;

namespace Project.Systems
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnRadius = 10f;
        [SerializeField] private float _spawnInterval = 2f;

        private float _timer;

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer > 0f)
                return;

            Spawn();
            _timer = _spawnInterval;
        }

        private void Spawn()
        {
            Vector3 pos = Random.insideUnitSphere * _spawnRadius;
            pos.y = 0f;
            pos += transform.position;

            PoolManager.Instance.EnemyFactory.Create(pos);
        }
    }
}