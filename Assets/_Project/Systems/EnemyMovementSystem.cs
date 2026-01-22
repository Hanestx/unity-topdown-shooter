using UnityEngine;
using System.Collections.Generic;
using Project.Components;

namespace Project.Systems
{
    public class EnemyMovementSystem : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _spawner;
        [SerializeField] private Transform _player;

        private readonly List<EnemyMovementComponent> _enemies = new();

        private void OnEnable()
        {
            _spawner.OnEnemySpawned += RegisterEnemy;
        }

        private void OnDisable()
        {
            _spawner.OnEnemySpawned -= RegisterEnemy;
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                MoveTowardsPlayer(_enemies[i]);
            }
        }

        private void RegisterEnemy(Enemy enemy)
        {
            if (enemy.TryGetComponent(out EnemyMovementComponent movement))
            {
                _enemies.Add(movement);

                enemy.GetComponent<HealthComponent>().OnDied += () =>
                {
                    _enemies.Remove(movement);
                };
            }
        }

        private void MoveTowardsPlayer(EnemyMovementComponent enemy)
        {
            Vector3 direction = _player.position - enemy.transform.position;
            direction.y = 0f;

            if (direction.sqrMagnitude < 0.01f)
                return;

            direction.Normalize();

            Vector3 velocity = direction * enemy.MoveSpeed;

            enemy.Rigidbody.linearVelocity = new Vector3(
                velocity.x,
                enemy.Rigidbody.linearVelocity.y,
                velocity.z
            );

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            enemy.transform.rotation = Quaternion.Slerp(
                enemy.transform.rotation,
                targetRotation,
                10f * Time.fixedDeltaTime
            );
        }
    }
}