using UnityEngine;

namespace Project.Components
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyMovementComponent : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 3f;

        private Rigidbody _rigidbody;

        public float MoveSpeed => _moveSpeed;
        public Rigidbody Rigidbody => _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.useGravity = false;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}