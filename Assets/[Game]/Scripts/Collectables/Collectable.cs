using System;
using _Game_.Scripts.Utilities;
using UnityEngine;

namespace _Game_.Scripts.Collectables
{
    public abstract class Collectable : MonoBehaviour
    {
        [SerializeField] private CollectableInteraction collectableInteraction;
        [SerializeField] private CollectableAnimation collectableAnimation;

        private Action<Collectable> onCollect;
        private int amount;
        private string poolTag;
        public int GetAmount
        {
            get { return amount; }
        }

        public virtual void Init(int _amount, string _poolTag ,Action<Collectable> _onCollect)
        {
            poolTag = _poolTag;
            amount = _amount;
            onCollect = _onCollect;
            collectableInteraction.Init(Collect);
            collectableAnimation.Init();
        }
        

        private void Collect()
        {
            onCollect?.Invoke(this);
            collectableAnimation.CollectAnimation(Destroy);
        }

        private void Destroy()
        {
            GenericObjectPool.Instance.ReleasePooledObject(poolTag,this);
        }
    }
}