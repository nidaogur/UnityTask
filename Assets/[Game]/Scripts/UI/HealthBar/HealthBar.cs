using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Game_.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private HealthBarAnimation healthBarAnimation;
        
        [SerializeField] private int maxHealth=100;
        private int _currentHealth;
        private Action _onHealthOver;
        public void Init(Action onHealthOver)
        {
            healthBarAnimation.Init();
            _currentHealth = maxHealth;
            HealthBarUpdate(_currentHealth);
            _onHealthOver = onHealthOver;
        }
        public void HealthBarUpdate(int amount)
        {
            _currentHealth += amount;
            _currentHealth=   Mathf.Clamp(_currentHealth, 0, 100);
            healthBarAnimation.HealthBarTween(_currentHealth,maxHealth);
            if (_currentHealth <= 0)
            {
                _onHealthOver?.Invoke();
            }
        }
    }
}