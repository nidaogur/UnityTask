using System;
using _Game_.Scripts.Interface;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace _Game_.Scripts
{
    public abstract class CollectableInteraction : MonoBehaviour, IInteractable
    {
        private Action onInteract;

        public virtual void Init(Action _onInteract)
        {
            onInteract = _onInteract;
        }

        public void Interact()
        {
            onInteract?.Invoke();
        }
    }
}