using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Game_.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private HealthBarAnimation healthBarAnimation;
        
        [SerializeField] private int maxHealth=100;
        private int currentHealth;
        public void Init()
        {
            healthBarAnimation.Init();
            currentHealth = maxHealth;
            HealthBarUpdate(currentHealth);
        }
        public void HealthBarUpdate(int amount)
        {
            currentHealth += amount;
            currentHealth=   Mathf.Clamp(currentHealth, 0, 100);
            healthBarAnimation.HealthBarTween(currentHealth,maxHealth);
           
        }
    }
}