using System;
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

        private Action _onHealthOver;
        public void Init(Action onHealthOver)
        {
            scoreBar.Init();
            healthBar.Init(GameOver);
        }
        
        private void GameOver()
        {
            gameOverPanel.SetActive(true);
            _onHealthOver?.Invoke();
        }
        
    }
}