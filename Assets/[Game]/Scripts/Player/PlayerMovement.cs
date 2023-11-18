using UnityEngine;

namespace _Game_.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
       [SerializeField] private PlayerMovementData playerMovementData;
        public void Init()
        {
            
        }
        
        public void Move(Vector2 inputVector)
        {
            var lookDirection = (Vector3.right * inputVector.x + Vector3.forward * inputVector.y);
            transform.forward=Vector3.Lerp(transform.forward,lookDirection,playerMovementData.rotationSpeed*Time.deltaTime);
            transform.position += transform.forward * (Time.deltaTime * playerMovementData.movementSpeed);
           
        }
        
    }
}
