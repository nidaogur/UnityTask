using UnityEngine;

namespace _Game_.Scripts.Player
{
   public class Player : MonoBehaviour
   {
      [SerializeField] private PlayerInput playerInput;
      [SerializeField] private PlayerInteraction playerInteraction;
      [SerializeField] private PlayerMovement playerMovement;
      [SerializeField] private PlayerAnimation playerAnimation;
      [SerializeField] private PlayerHealth playerHealth;
      [SerializeField] private PlayerData playerData;
      public void Init()
      {
         playerAnimation.Init();
         playerInput.Init(playerMovement.Move);
         playerInteraction.Init();
         playerHealth.Init(playerData);
         playerMovement.Init();
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
