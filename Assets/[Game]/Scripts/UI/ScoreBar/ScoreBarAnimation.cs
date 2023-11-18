using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

namespace _Game_.Scripts.UI
{
    public class ScoreBarAnimation : MonoBehaviour
    {
        [SerializeField] private Transform scoreBarCoinImage;
        [SerializeField] private TweenSettingsData scoreBarTweenSettings;
        private Tweener tween;
        public void Init()
        {
        
        }
        public void ScoreBarTween()
        {
            tween?.Kill();
            tween = scoreBarCoinImage.DOScale(Vector3.one, scoreBarTweenSettings.duration).From(Vector3.one * .7f).SetEase(scoreBarTweenSettings.ease).OnComplete(() => tween = null);
        }
    }
}
