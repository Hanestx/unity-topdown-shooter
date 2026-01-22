using UnityEngine;
using Project.Core.Pool;

namespace Project.Systems
{
    public class AutoAttackSystem : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _attackRange = 8f;
        [SerializeField] private float _fireRate = 2f;
        [SerializeField] private LayerMask _enemyMask;

        private float _cooldown;

        private void Update()
        {
            _cooldown -= Time.deltaTime;
            if (_cooldown > 0f)
                return;

            Transform target = FindClosestEnemy();
            if (target == null)
                return;

            Shoot(target.position);
            _cooldown = 1f / _fireRate;
        }

        private Transform FindClosestEnemy()
        {
            Collider[] hits = Physics.OverlapSphere(
                _player.position,
                _attackRange,
                _enemyMask
            );

            if (hits.Length == 0)
                return null;

            float bestDistance = float.MaxValue;
            Transform bestTarget = null;

            Vector3 playerPos = _player.position;

            foreach (Collider hit in hits)
            {
                Vector3 delta = hit.transform.position - playerPos;
                float sqrDistance = delta.sqrMagnitude;

                if (sqrDistance < bestDistance)
                {
                    bestDistance = sqrDistance;
                    bestTarget = hit.transform;
                }
            }

            return bestTarget;
        }

        private void Shoot(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - _player.position;
            direction.y = 0f;

            if (direction.sqrMagnitude < 0.001f)
                return;

            direction.Normalize();

            Bullet bullet = PoolManager.Instance.SpawnBullet();
            bullet.transform.position = _player.position + direction;
            bullet.transform.rotation = Quaternion.LookRotation(direction);
            bullet.Init(direction);
        }
    }
}
