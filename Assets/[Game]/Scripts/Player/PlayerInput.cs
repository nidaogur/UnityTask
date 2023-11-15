using System;
using UnityEngine;

namespace _Game_.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private VariableJoystick joystick;
        private Camera _camera;
        private Vector3 _lastDelta;

        private Action<Vector2> onDrag;
        public void Init(Action<Vector2> _onDrag)
        {
            _camera = Camera.main;
            onDrag = _onDrag;
        }
        private void Update()
        {
            if(joystick.Vertical==0 && joystick.Horizontal==0)
                return;
            
            var delta= joystick.Horizontal * _camera.transform.right + joystick.Vertical * _camera.transform.up;
            onDrag?.Invoke(delta);
        }
       
    }
}
