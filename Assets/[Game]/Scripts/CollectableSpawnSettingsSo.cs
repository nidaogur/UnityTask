using _Game_.Scripts.Collectables;
using UnityEngine;

namespace _Game_.Scripts
{
    [CreateAssetMenu(fileName="CollectableSpawnSettings")]
    public class CollectableSpawnSettingsSo : ScriptableObject
    {
        public Collectable prefab;
        public int spawnAmount;
        public int collectAmount;
    }
}