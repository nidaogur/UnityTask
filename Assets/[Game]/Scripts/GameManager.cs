using System;
using _Game_.Scripts.Collectables;
using _Game_.Scripts.Collectables.Coin;
using UnityEngine;

namespace _Game_.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Coin coinPrefab;
        private Action<Collectable> onCollect;

        public void Init(Action<Collectable> _onCollect)
        {
            onCollect = _onCollect;
            Spawn();
        }

        private void Spawn()
        {
            for (int i = 0; i < 10; i++)
            {
                var coin = Instantiate(coinPrefab);
                coin.transform.position = Vector3.forward * i;
                coin.Init(5, onCollect); //TODO SOdan amount
            }
        }
    }
}