using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnRadius = 10f;
    [SerializeField] private float _spawnInterval = 2f;

    private float _timer;

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer > 0f)
            return;

        SpawnEnemy();
        _timer = _spawnInterval;
    }

    private void SpawnEnemy()
    {
        Vector3 position = Random.insideUnitSphere * _spawnRadius;
        position.y = 0f;
        position += transform.position;

        Instantiate(_enemyPrefab, position, Quaternion.identity);
    }
}