using UnityEngine;

namespace _Game_.Scripts.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        private int _currentHealth;
        public void Init(PlayerData playerData)
        {
            _currentHealth = playerData.playerHealth;
        }

        public int UpdateHealth(int amount)
        {
            _currentHealth += amount;
            _currentHealth=   Mathf.Clamp(_currentHealth, 0, 100);
            return _currentHealth;
        }
    }
}