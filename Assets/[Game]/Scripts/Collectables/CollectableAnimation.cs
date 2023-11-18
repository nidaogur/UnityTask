using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game_.Scripts.Collectables
{
    [Serializable]
    public class CollectableIdleTweenSettingsData : TweenSettingsData
    {
        public Vector2 minMaxDelay;
        public float heightAmount = 1f;
        public LoopType loopType = LoopType.Yoyo;
        public RotateMode rotateMode = RotateMode.FastBeyond360;
    }
    public abstract class CollectableAnimation : MonoBehaviour
    {
        [SerializeField] private TweenSettingsData collectAnimationTweenSettings;
        [SerializeField] private CollectableIdleTweenSettingsData idleAnimationTweenSettings;

        public virtual void Init()
        {
            transform.localScale=Vector3.one;
            IdleAnimation();
        }

        protected virtual void IdleAnimation()
        {
            var seq = DOTween.Sequence();
            seq.SetDelay(Random.Range(idleAnimationTweenSettings.minMaxDelay.x,
                idleAnimationTweenSettings.minMaxDelay.y));
            seq.Append(transform.DOLocalMoveY(transform.localPosition.y + idleAnimationTweenSettings.heightAmount,
                idleAnimationTweenSettings.duration));
            seq.Join(transform.DORotate(Vector3.up * 360, idleAnimationTweenSettings.duration,
                idleAnimationTweenSettings.rotateMode));
            seq.SetLoops(-1, idleAnimationTweenSettings.loopType);
            seq.Play();
            seq.SetId(GetTweenId());
        }

        public virtual void CollectAnimation(Action complete)
        {
            transform.DOScale(Vector3.zero, collectAnimationTweenSettings.duration)
                .SetEase(collectAnimationTweenSettings.ease).OnComplete(() => { complete(); }).SetId(GetTweenId());
        }

        public void DestroyAnimation()
        {
            DOTween.Kill(GetTweenId());
        }

        private string GetTweenId()
        {
            return $"CollectableTween{GetInstanceID()}";
        }
    }
}