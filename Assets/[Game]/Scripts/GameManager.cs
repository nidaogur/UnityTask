using System;
using _Game_.Scripts.Collectables;
using _Game_.Scripts.Collectables.Coin;
using UnityEngine;

namespace _Game_.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Coin coinPrefab;
        public int currentCoin;
        private UIManager uiManager;
        public void Init(UIManager _uiManager)
        {
            uiManager = _uiManager;
            LoadGame();
            Spawn();
        }

        private void LoadGame()
        {
            currentCoin = PlayerPrefs.GetInt("CurrentCoin", 0);
            uiManager.ScoreUpdate(currentCoin);
        }

        private void Spawn()
        {
            for (int i = 0; i < 10; i++)
            {
                var coin = Instantiate(coinPrefab);
                coin.transform.position = Vector3.forward * i;
                coin.Init(500, OnCollect); //TODO SOdan amount
            }
        }
        
        private void OnCollect(Collectable collectable)
        {
            var amount = collectable.GetAmount;
            if (collectable is Coin)
            { 
                ScoreIncrease(amount);
            }
            
            collectable.Destroy();
        }
        
        private void ScoreIncrease(int amount)
        {
            currentCoin += amount;
            PlayerPrefs.SetInt("CurrentCoin",currentCoin);
            uiManager.ScoreUpdate(currentCoin);
        }
    }
}