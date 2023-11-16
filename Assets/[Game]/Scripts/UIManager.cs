using TMPro;
using UnityEngine;

namespace _Game_.Scripts
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        public void Init()
        {
        }
        public void ScoreUpdate(int scoreValue)
        {
            var formattedScore = NumberFormatter.FormatNumber(scoreValue);
            scoreText.text = formattedScore;
        }
    }
}