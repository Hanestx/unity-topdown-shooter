using UnityEngine;
using Project.Components;
using Project.Input;

namespace Project.Systems
{
    public class PlayerMovementSystem : MonoBehaviour
    {
        [SerializeField] private MovementComponent _movement;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private PlayerInputReader _input;

        private Vector3 _moveDirection;
        
        private void Update()
        {
            Vector2 input = _input.MoveInput;
            _moveDirection = new Vector3(input.x, 0f, input.y);

            if (_moveDirection.sqrMagnitude > 1f)
                _moveDirection.Normalize();
            
            Rotate(_moveDirection);
        }

        private void FixedUpdate()
        {
            Move(_moveDirection);
        }


        private void Move(Vector3 direction)
        {
            Vector3 velocity = direction * _movement.MoveSpeed;
            _movement.Rigidbody.linearVelocity =
                new Vector3(velocity.x, _movement.Rigidbody.linearVelocity.y, velocity.z);
        }

        private void Rotate(Vector3 direction)
        {
            if (direction.sqrMagnitude < 0.001f)
                return;

            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            _playerTransform.rotation = Quaternion.Slerp(
                _playerTransform.rotation,
                targetRotation,
                Time.fixedDeltaTime * 15f
            );
        }
    }
}