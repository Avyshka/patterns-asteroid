using Asteroids.Enemies.Factories;
using Asteroids.Interfaces;
using Asteroids.Players.Controllers;
using Asteroids.Players.Models;
using Asteroids.Players.Views;
using Asteroids.Pools;
using Asteroids.Pools.Interfaces;
using Asteroids.ScriptableObjects;
using UnityEngine;

namespace Asteroids
{
    public class GameContext : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private EnemyData meteorData;
        [SerializeField] private EnemyData asteroidData;
        [SerializeField] private EnemyData cometData;
        
        private IUpdatable _playerController;

        private void Start()
        {
            _playerController = new PlayerController(
                new PlayerModel(playerData),
                FindObjectOfType<PlayerView>()
            );
            
            IViewServices viewServices = new ViewServices();

            var meteorFactory = new MeteorFactory(viewServices);
            meteorFactory.Create(new Health(2.0f));
        }

        private void Update()
        {
            _playerController.OnUpdate(Time.deltaTime);
        }
    }
}