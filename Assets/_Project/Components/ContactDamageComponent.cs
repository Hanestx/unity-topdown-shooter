using UnityEngine;
using Project.Components;

namespace Project.Components
{
    public class ContactDamageComponent : MonoBehaviour
    {
        [SerializeField] private int _damage = 10;
        [SerializeField] private float _damageCooldown = 0.5f;
        [SerializeField] private LayerMask _targetMask;

        private float _cooldownTimer;

        private void Update()
        {
            if (_cooldownTimer > 0f)
                _cooldownTimer -= Time.deltaTime;
        }

        private void OnCollisionStay(Collision collision)
        {
            if (_cooldownTimer > 0f)
                return;

            if (((1 << collision.gameObject.layer) & _targetMask) == 0)
                return;

            if (!collision.gameObject.TryGetComponent(out HealthComponent health))
                return;

            health.TakeDamage(_damage);
            _cooldownTimer = _damageCooldown;
        }
    }
}