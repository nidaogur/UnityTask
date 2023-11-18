using _Game_.Scripts.Utilities;
using AssetKits.ParticleImage;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Game_.Scripts.UI
{
    public class ScoreBar : MonoBehaviour
    {
        [SerializeField] private ScoreBarAnimation scoreBarAnimation;
        [SerializeField] private ParticleImage coinParticle;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private int maxParticle;
        private Camera cam;
        private int score;
        public void Init()
        {
            cam=CameraManager.Instance.MainCamera;
            scoreBarAnimation.Init();
            coinParticle.onStop.AddListener(CoinParticleComplete);
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
            if (amount > maxParticle) amount = maxParticle;
            coinParticle.rateOverTime = amount;
            coinParticle.Play();
            score = currentScore;
        }

        private void CoinParticleComplete() 
        {
            scoreBarAnimation.ScoreBarTween();
            ScoreUpdate(score);
        }
    }
}