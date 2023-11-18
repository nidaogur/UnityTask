using UnityEngine;

namespace _Game_.Scripts.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "SO/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        public string playerName;
        public int playerHealth;
    }
}