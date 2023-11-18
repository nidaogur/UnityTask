using System;
using UnityEngine;

namespace _Game_.Scripts.Player
{
    public class PlayerInput : MonoBehaviour, IPlayerInput
    {
        [SerializeField] private VariableJoystick joystick;
        private Camera _camera;
        private Vector3 _lastDelta;

        private Action<Vector2> _onDrag;

        public void Init(Action<Vector2> onDrag)
        {
            _camera = CameraManager.Instance.MainCamera;
            _onDrag = onDrag;
        }

        private void Update()
        {
            CalculateInputVector();
        }

        public void CalculateInputVector()
        {
            if (joystick.Vertical == 0 && joystick.Horizontal == 0)
                return;

            var delta = joystick.Horizontal * _camera.transform.right + joystick.Vertical * _camera.transform.up;
            _onDrag?.Invoke(delta);
        }
    }
}