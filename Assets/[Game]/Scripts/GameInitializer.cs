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
            gameManager.Init(uiManager);
            uiManager.Init();
        }
    }
}