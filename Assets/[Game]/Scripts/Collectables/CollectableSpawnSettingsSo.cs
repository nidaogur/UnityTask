using UnityEngine;

namespace _Game_.Scripts.Collectables
{
    [CreateAssetMenu(fileName="CollectableSpawnSettings",menuName = "SO/CollectableSpawnSettings", order = 0)]
    public class CollectableSpawnSettingsSo : ScriptableObject
    {
        public string poolTag;
        public int spawnAmount;
        public int collectAmount;
        public float spawnRadius = 12f;
    }
}