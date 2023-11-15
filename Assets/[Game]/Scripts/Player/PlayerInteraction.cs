using System;
using UnityEngine;

namespace _Game_.Scripts.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        public void Init()
        {
      
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.attachedRigidbody==null) return;
            if (other.attachedRigidbody.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
    }
}
