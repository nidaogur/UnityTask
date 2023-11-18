using System;
using _Game_.Scripts.Utilities;
using UnityEngine;

namespace _Game_.Scripts.Collectables
{
    public abstract class Collectable : MonoBehaviour
    {
        [SerializeField] private CollectableInteraction collectableInteraction;
        [SerializeField] private CollectableAnimation collectableAnimation;

        private Action<Collectable> _onCollect;
        private int _amount;
        private string _poolTag;

        public int GetAmount
        {
            get { return _amount; }
        }

        public virtual void Init(int amount, string poolTag, Action<Collectable> onCollect)
        {
            _poolTag = poolTag;
            _amount = amount;
            _onCollect = onCollect;
            collectableInteraction.Init(Collect);
            collectableAnimation.Init();
        }


        private void Collect()
        {
            _onCollect?.Invoke(this);
            collectableAnimation.CollectAnimation(Destroy);
        }

        private void Destroy()
        {
            collectableAnimation.DestroyAnimation();
            GenericObjectPool.Instance.ReleasePooledObject(_poolTag, this);
        }
    }
}