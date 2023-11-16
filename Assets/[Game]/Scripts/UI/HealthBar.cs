using UnityEngine;
using UnityEngine.UI;

namespace _Game_.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private int maxHealth;
        private int currentHealth;
        
        public void Init()
        {
        }
        public void HealthBarUpdate(int amount)
        {
            currentHealth += amount;
            healthBar.fillAmount = (float)currentHealth/maxHealth;
        }
    }
}