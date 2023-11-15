using System;
using UnityEngine;

namespace _Game_.Scripts.Collectables
{
    public abstract class Collectable : MonoBehaviour
    {
        [SerializeField] private CollectableInteraction collectableInteraction;
        [SerializeField] private CollectableAnimation collectableAnimation;

        private Action<Collectable> onCollect;
        private int amount;
        public int GetAmount
        {
            get { return amount; }
        }

        public virtual void Init(int _amount, Action<Collectable> _onCollect)
        {
            amount = _amount;
            onCollect = _onCollect;
            collectableInteraction.Init(Collect);
            collectableAnimation.Init();
        }

        private void Collect()
        {
            onCollect?.Invoke(this);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}