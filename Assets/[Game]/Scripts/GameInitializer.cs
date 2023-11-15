using UnityEngine;

namespace _Game_.Scripts
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private Player.Player player;
        private void Start()
        {
            player.Init();
        }
    }
} 
