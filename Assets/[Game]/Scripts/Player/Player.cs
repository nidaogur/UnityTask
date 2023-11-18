using UnityEngine;

namespace _Game_.Scripts.Player
{
   [RequireComponent(typeof(IPlayerMove))]
   [RequireComponent(typeof(IPlayerInput))]
   public class Player : MonoBehaviour
   {
      [SerializeField] private PlayerInteraction playerInteraction;
      [SerializeField] private PlayerAnimation playerAnimation;
      [SerializeField] private PlayerHealth playerHealth;
      [SerializeField] private PlayerData playerData;
      private IPlayerMove playerMovement;
       private IPlayerInput playerInput;
      public void Init()
      {
         playerMovement = GetComponent<IPlayerMove>();
         playerInput = GetComponent<IPlayerInput>();
         
         playerAnimation.Init();
         playerMovement.Init();
         playerInput.Init(playerMovement.Move);
         playerInteraction.Init();
         playerHealth.Init(playerData);
       
      }

      public PlayerData GetPlayerData()
      {
         return playerData;
      }

      public int UpdateHealth(int amount)
      {
         return playerHealth.UpdateHealth(amount);
      }
   }
}
