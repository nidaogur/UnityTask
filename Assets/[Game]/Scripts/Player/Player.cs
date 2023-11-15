using UnityEngine;

namespace _Game_.Scripts.Player
{
   public class Player : MonoBehaviour
   {
      [SerializeField] private PlayerInput playerInput;
      [SerializeField] private PlayerHealth playerHealth;
      [SerializeField] private PlayerInteraction playerInteraction;
      [SerializeField] private PlayerMovement playerMovement;
      [SerializeField] private PlayerAnimation playerAnimation;

      public void Init()
      {
         playerAnimation.Init();
         playerHealth.Init();
         playerInput.Init(playerMovement.Move);
         playerInteraction.Init();
         playerMovement.Init();
      }
   }
}
