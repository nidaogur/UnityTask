using UnityEngine;

namespace _Game_.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public void Init()
        {
            
        }
        
        public void Move(Vector2 inputVector)
        {
            transform.position += (Vector3.right*inputVector.x+Vector3.forward*inputVector.y) * Time.deltaTime;
        }
        
    }
}
