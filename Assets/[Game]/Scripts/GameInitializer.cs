using System;
using _Game_.Scripts.UI;
using _Game_.Scripts.Utilities;
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
            uiManager.Init(player.GetPlayerData());
            gameManager.Init(uiManager,player);
           
           
        }
    }
}