using System;
using UnityEngine;

namespace _Game_.Scripts.Player
{
    public interface IPlayerInput
    {
        public void Init(Action<Vector2> onDrag);
        public void CalculateInputVector();
    }
}