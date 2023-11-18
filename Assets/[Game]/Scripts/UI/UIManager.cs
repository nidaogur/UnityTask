using System;
using _Game_.Scripts.Player;
using TMPro;
using UnityEngine;

namespace _Game_.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private HealthBar healthBar;
        public HealthBar HealthBar { get => healthBar; }
        
        [SerializeField] private ScoreBar scoreBar;

        public ScoreBar ScoreBar { get => scoreBar; }
        [SerializeField] private GameObject gameOverPanel;
        public void Init(PlayerData playerData)
        {
            scoreBar.Init();
            healthBar.Init(playerData);
           
        }
        
        public void GameOver()
        {
            gameOverPanel.SetActive(true);
        }
        
    }
}