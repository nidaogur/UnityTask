using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

namespace _Game_.Scripts.UI
{
    public class ScoreBarAnimation : MonoBehaviour
    {
        [SerializeField] private Transform scoreBarCoinImage;
        [SerializeField] private Ease ease;
        [SerializeField] private float duration=.3f;
        private Tweener tween;
        public void Init()
        {
        
        }
        public void ScoreBarTween()
        {
            tween?.Kill();
            tween = scoreBarCoinImage.DOScale(Vector3.one, duration).From(Vector3.one * .7f).SetEase(ease).OnComplete(() => tween = null);
        }
    }
}
