using UnityEngine;
using Project.Components;

namespace Project.Systems
{
    public class PlayerMovementSystem : MonoBehaviour
    {
        [SerializeField] private MovementComponent _movement;
        [SerializeField] private Transform _playerTransform;


        private void FixedUpdate()
        {
            if (_movement == null)
                return;

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new(horizontal, 0f, vertical);

            Move(direction);
            Rotate(direction);
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