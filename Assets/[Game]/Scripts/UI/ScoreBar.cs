using AssetKits.ParticleImage;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Game_.Scripts.UI
{
    public class ScoreBar : MonoBehaviour
    {
        [SerializeField] private ParticleImage coinParticle;
        [SerializeField] private TMP_Text scoreText;
        
        private Camera cam;
        private int score;
        public void Init()
        {
            cam=Camera.main;
        }
        public void ScoreUpdate(int scoreValue)
        {
            var formattedScore = NumberFormatter.FormatNumber(scoreValue);
            scoreText.text = formattedScore;
        }

        public void ScoreUpdate(int amount,int currentScore, Vector3 position)
        {
            var pos = cam.WorldToScreenPoint(position);
            coinParticle.transform.position = pos;
            coinParticle.rateOverTime = amount;
            coinParticle.Play();
            score = currentScore;
        }

        public void ScoreTextUpdate()
        {
            var formattedScore = NumberFormatter.FormatNumber(score);
            scoreText.text = formattedScore;
        }
    }
}