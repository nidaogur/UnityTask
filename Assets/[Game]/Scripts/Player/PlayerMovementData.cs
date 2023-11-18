using UnityEngine;

namespace _Game_.Scripts
{
    [CreateAssetMenu(fileName = "PlayerMovement", menuName = "SO/PlayerMovementData", order = 0)]
    public class PlayerMovementData : ScriptableObject
    {
        public float rotationSpeed;
        public float movementSpeed;
    }
}