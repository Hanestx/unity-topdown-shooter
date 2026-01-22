using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Input
{
    public class PlayerInputReader : MonoBehaviour
    {
        public Vector2 MoveInput { get; private set; }

        private PlayerInputActions _actions;

        private void Awake()
        {
            _actions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _actions.Enable();
            _actions.Gameplay.Move.performed += OnMove;
            _actions.Gameplay.Move.canceled += OnMove;
        }

        private void OnDisable()
        {
            _actions.Gameplay.Move.performed -= OnMove;
            _actions.Gameplay.Move.canceled -= OnMove;
            _actions.Disable();
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            MoveInput = context.ReadValue<Vector2>();
        }
    }
}