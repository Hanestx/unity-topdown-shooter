using UnityEngine;

public class AutoAttackSystem : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _attackRange = 8f;
    [SerializeField] private float _fireRate = 2f;
    [SerializeField] private GameObject _bulletPrefab;
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
        Collider[] hits = Physics.OverlapSphere(_player.position, _attackRange, _enemyMask);
        if (hits.Length == 0)
            return null;

        float bestDistance = float.MaxValue;
        Transform bestTarget = null;

        foreach (Collider hit in hits)
        {
            float distance = (hit.transform.position - _player.position).sqrMagnitude;
            if (distance < bestDistance)
            {
                bestDistance = distance;
                bestTarget = hit.transform;
            }
        }

        return bestTarget;
    }

    private void Shoot(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - _player.position;
        direction.y = 0f;

        GameObject bullet = Instantiate(
            _bulletPrefab,
            _player.position + direction.normalized,
            Quaternion.LookRotation(direction)
        );

        bullet.GetComponent<Bullet>().Init(direction.normalized);
    }
}
