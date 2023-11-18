using System;
using _Game_.Scripts.Collectables;
using _Game_.Scripts.Collectables.Coin;
using _Game_.Scripts.Collectables.HealthBooster;
using _Game_.Scripts.Collectables.LifeDrainer;
using _Game_.Scripts.UI;
using _Game_.Scripts.Utilities;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace _Game_.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CollectableSpawnSettingsSo lifeDrainer;
        [SerializeField] private CollectableSpawnSettingsSo healthBooster;
        [SerializeField] private CollectableSpawnSettingsSo coin;
        private UIManager _uiManager;
        private Player.Player _player;

        public void Init(UIManager uiManager, Player.Player player)
        {
            _uiManager = uiManager;
            _player = player;
            LoadGame();
            Spawn(lifeDrainer);
            Spawn(healthBooster);
            Spawn(coin);
        }

        private void LoadGame()
        {
            _uiManager.ScoreBar.ScoreUpdate(DataManager.Coin);
        }

        private void Spawn(CollectableSpawnSettingsSo collectableSpawnSettingsSo)
        {
            for (int i = 0; i < collectableSpawnSettingsSo.spawnAmount; i++)
            {
                var collectable = GenericObjectPool.Instance.Spawn<Collectable>(collectableSpawnSettingsSo.poolTag,
                    Vector3.Scale(Random.insideUnitSphere * collectableSpawnSettingsSo.spawnRadius,
                        Vector3.right + Vector3.forward));
                collectable.Init(collectableSpawnSettingsSo.collectAmount, collectableSpawnSettingsSo.poolTag,
                    OnCollect);
            }
        }

        private void OnCollect(Collectable collectable)
        {
            var amount = collectable.GetAmount;
            switch (collectable)
            {
                case Coin:
                    ScoreIncrease(amount, collectable.transform.position);
                    break;
                case HealthBooster:
                    HealthIncrease(amount);
                    break;
                case LifeDrainer:
                    HealthIncrease(amount);
                    break;
            }
        }

        private void ScoreIncrease(int amount, Vector3 collectPosition)
        {
            DataManager.Coin += amount;
            _uiManager.ScoreBar.ScoreUpdate(amount, DataManager.Coin, collectPosition);
        }

        private void HealthIncrease(int amount)
        {
            var health = _player.UpdateHealth(amount);
            _uiManager.HealthBar.HealthBarUpdate(health);
            if (health <= 0)
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            _uiManager.GameOver();
        }
    }
}