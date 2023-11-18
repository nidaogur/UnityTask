using System;
using UnityEngine;

namespace _Game_.Scripts.Collectables.LifeDrainer
{
    public class LifeDrainerAnimation : CollectableAnimation
    {
        public override void CollectAnimation(Action complete)
        {
            base.CollectAnimation(complete);
            CameraManager.Instance.Shake(1,0.5f);
        }
    }
}
