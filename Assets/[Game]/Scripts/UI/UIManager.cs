using UnityEngine;

namespace _Game_.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private HealthBar healthBar;
        public HealthBar HealthBar { get => healthBar; }
        
        [SerializeField] private ScoreBar scoreBar;

        public ScoreBar ScoreBar { get => scoreBar; }

        public void Init()
        {
            scoreBar.Init();
            healthBar.Init();
        }
        
    }
}