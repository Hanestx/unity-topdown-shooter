using UnityEngine;

namespace Project.Components
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovementComponent : MonoBehaviour
    {
        public float MoveSpeed => _moveSpeed;
        public Rigidbody Rigidbody => _rigidbody;


        [SerializeField] private float _moveSpeed = 6f;


        private Rigidbody _rigidbody;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _rigidbody.useGravity = false;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}