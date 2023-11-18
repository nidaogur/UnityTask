using System;
using System.Net.Mime;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Game_.Scripts.UI
{
    [Serializable]
    public class HealthBarTweenSettingsData : TweenSettingsData
    {
        public Color startColor=Color.red;
        public Color endColor=Color.green;
        public AnimationCurve colorCurve;
    }
    public class HealthBarAnimation : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private HealthBarTweenSettingsData healthBarTweenSettingsData;
        private Tween tween;
        public void Init()
        {
            
        }

        public void HealthBarTween(int currentHealth, int maxHealth)
        {
            var ratio = (float)currentHealth / maxHealth;
            tween?.Kill();
            healthBar.DOFillAmount(ratio, .5f).OnComplete(()=> tween=null);
            healthBar.color=Color.Lerp(healthBarTweenSettingsData.startColor,healthBarTweenSettingsData.endColor,
                healthBarTweenSettingsData.colorCurve.Evaluate(ratio));
        }
    }
}