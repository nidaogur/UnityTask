using System.Net.Mime;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Game_.Scripts.UI
{
    public class HealthBarAnimation : MonoBehaviour
    {
        [SerializeField] private Image healthBar;

        [SerializeField] private Color startColor=Color.red;
        [SerializeField] private Color endColor=Color.green;
        [SerializeField] private AnimationCurve colorCurve;
        public void Init()
        {
            
        }

        public void HealthBarTween(int currentHealth, int maxHealth)
        {
            var ratio = (float)currentHealth / maxHealth;
            healthBar.DOFillAmount(ratio, .5f);
            healthBar.color=Color.Lerp(startColor,endColor,colorCurve.Evaluate(ratio));
        }
    }
}