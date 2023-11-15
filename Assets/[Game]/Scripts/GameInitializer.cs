using _Game_.Scripts.Collectables;
using _Game_.Scripts.Collectables.Coin;
using UnityEngine;

namespace _Game_.Scripts
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private Player.Player player;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private UIManager uiManager;
        private void Start()
        {
            player.Init();
            gameManager.Init(OnCollect);
        }
        private void OnCollect(Collectable collectable)
        {
            var amount = collectable.GetAmount;
            if (collectable is Coin)
            {
                Debug.Log("Coin Collected "+amount);
            }
            
            collectable.Destroy();
        }
    }
}