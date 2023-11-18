using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game_.Scripts.Collectables
{
    public abstract class CollectableAnimation : MonoBehaviour
    {
        public virtual void Init()
        {
            IdleAnimation();
        }

        public virtual void IdleAnimation()
        {
            
            var seq = DOTween.Sequence();
            seq.SetDelay(Random.Range(0f, 1f));
            seq.Append(transform.DOLocalMoveY(transform.localPosition.y + 1, 1f));
            seq.Join(transform.DORotate(Vector3.up * 180, 1f, RotateMode.FastBeyond360));
            seq.SetLoops(-1, LoopType.Yoyo);
            seq.Play();
        }

        public virtual void CollectAnimation(Action complete)
        {
            transform.DOScale(Vector3.zero, .2f).OnComplete(() =>
            {
                complete();
            });
        }
        
    }
}