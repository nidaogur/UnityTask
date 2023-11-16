using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game_.Scripts
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private Image healthBar;
        [SerializeField] private int maxHealth;
        private int currentHealth;
        public void Init()
        {
        }
        public void ScoreUpdate(int scoreValue)
        {
            var formattedScore = NumberFormatter.FormatNumber(scoreValue);
            scoreText.text = formattedScore;
        }

        public void ScoreUpdate(int scoreValue, Vector3 position)
        {
            var formattedScore = NumberFormatter.FormatNumber(scoreValue);
            scoreText.text = formattedScore;
        }
        public void HealthBarUpdate(int amount)
        {
            currentHealth += amount;
            healthBar.fillAmount = (float)currentHealth/maxHealth;
        }
    }
}