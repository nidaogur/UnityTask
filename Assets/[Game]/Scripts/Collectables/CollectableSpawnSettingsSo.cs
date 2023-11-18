using UnityEngine;

namespace _Game_.Scripts.Collectables
{
    [CreateAssetMenu(fileName="CollectableSpawnSettings")]
    public class CollectableSpawnSettingsSo : ScriptableObject
    {
        public string poolTag;
        public int spawnAmount;
        public int collectAmount;
    }
}