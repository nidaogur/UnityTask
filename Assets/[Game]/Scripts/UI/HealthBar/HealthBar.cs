using System;
using _Game_.Scripts.Player;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game_.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private HealthBarAnimation healthBarAnimation;

        [SerializeField] private TMP_Text nameText;
        private int _maxHealth;
        public void Init(PlayerData playerData)
        {
            healthBarAnimation.Init();
            _maxHealth = playerData.playerHealth;
            nameText.text = playerData.playerName;
            HealthBarUpdate(_maxHealth);
        }
        public void HealthBarUpdate(int currentHealth)
        {
            healthBarAnimation.HealthBarTween(currentHealth,_maxHealth);
        }
    }
}