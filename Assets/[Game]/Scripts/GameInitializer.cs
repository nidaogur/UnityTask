using _Game_.Scripts.UI;
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
            uiManager.Init(GameOver);
        }

        private void GameOver()
        {
            Time.timeScale = 0;
        }
    }
}