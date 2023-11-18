using UnityEngine;

namespace _Game_.Scripts.Player
{
    public interface IPlayerMove
    {
        public void Init();
        public void Move(Vector2 inputVector);
        
    }
}