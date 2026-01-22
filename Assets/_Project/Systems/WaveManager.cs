using UnityEngine;
using Project.Data;
using Project.Components;

namespace Project.Systems
{
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private WaveConfig[] _waves;
        [SerializeField] private EnemySpawner _spawner;

        private int _currentWaveIndex;
        private int _aliveEnemies;

        private void Start()
        {
            StartNextWave();
        }

        private void StartNextWave()
        {
            if (_currentWaveIndex >= _waves.Length)
                return;

            WaveConfig wave = _waves[_currentWaveIndex];
            _currentWaveIndex++;

            StartCoroutine(RunWave(wave));
        }

        private System.Collections.IEnumerator RunWave(WaveConfig wave)
        {
            _aliveEnemies = 0;

            _spawner.OnEnemySpawned += OnEnemySpawned;

            for (int i = 0; i < wave.EnemyCount; i++)
            {
                _spawner.SpawnEnemy();
                yield return new WaitForSeconds(wave.SpawnInterval);
            }

            _spawner.OnEnemySpawned -= OnEnemySpawned;
        }

        private void OnEnemySpawned(Enemy enemy)
        {
            _aliveEnemies++;
            enemy.GetComponent<HealthComponent>().OnDied += OnEnemyDied;
        }

        private void OnEnemyDied()
        {
            _aliveEnemies--;

            if (_aliveEnemies <= 0)
            {
                StartCoroutine(WaitAndStartNextWave());
            }
        }

        private System.Collections.IEnumerator WaitAndStartNextWave()
        {
            yield return new WaitForSeconds(
                _waves[_currentWaveIndex - 1].DelayBeforeNextWave
            );

            StartNextWave();
        }
    }
}