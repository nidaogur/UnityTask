using System;
using _Game_.Scripts.Collectables;
using _Game_.Scripts.Collectables.Coin;
using _Game_.Scripts.Collectables.HealthBooster;
using _Game_.Scripts.Collectables.LifeDrainer;
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
        
        public int currentCoin;
        
        private UIManager uiManager;
        private Player.Player player;
        public void Init(UIManager _uiManager)
        {
            uiManager = _uiManager;
            LoadGame();
            Spawn(lifeDrainer);
            Spawn(healthBooster);
            Spawn(coin);
        }

        private void LoadGame()
        {
            currentCoin = PlayerPrefs.GetInt("CurrentCoin", 0);
            uiManager.ScoreUpdate(currentCoin);
        }

        private void Spawn(CollectableSpawnSettingsSo collectableSpawnSettingsSo)
        {
            for (int i = 0; i < collectableSpawnSettingsSo.spawnAmount; i++)
            {
                var collectable = Instantiate(collectableSpawnSettingsSo.prefab);
                collectable.transform.position =Vector3.Scale(Random.insideUnitSphere * 10,Vector3.right+Vector3.forward) ;
                collectable.Init(collectableSpawnSettingsSo.collectAmount, OnCollect);
            }
        }
        
        private void OnCollect(Collectable collectable)
        {
            var amount = collectable.GetAmount;
            switch (collectable)
            {
                case Coin:
                    ScoreIncrease(amount,collectable.transform.position);
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
            currentCoin += amount;
            PlayerPrefs.SetInt("CurrentCoin",currentCoin);
            uiManager.ScoreUpdate(currentCoin,collectPosition);
        }

        private void HealthIncrease(int amount)
        {
            uiManager.HealthBarUpdate(amount);
        }
    }
}