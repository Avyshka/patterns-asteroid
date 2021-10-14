using Asteroids.Enemies.Factories;
using Asteroids.Entities.Enums;
using Asteroids.Entities.Factories;
using Asteroids.Players.Controllers;
using Asteroids.Players.Models;
using Asteroids.Players.Views;
using Asteroids.Pools;
using Asteroids.ScriptableObjects;
using Asteroids.Weapons.Controllers;
using Asteroids.Weapons.Models;
using Asteroids.Weapons.Views;
using UnityEngine;

namespace Asteroids
{
    public class GameScene
    {
        private readonly UpdateManager _updateManager = new UpdateManager();
        private readonly FixedUpdateManager _fixedUpdateManager = new FixedUpdateManager();
        private readonly EntityFactory _enemyFactory;

        public GameScene()
        {
            _enemyFactory = new EntityFactory();
            _enemyFactory.AddFactory(EntityTypes.Meteor, new MeteorFactory());
            _enemyFactory.AddFactory(EntityTypes.Asteroid, new AsteroidFactory());
            _enemyFactory.AddFactory(EntityTypes.Comet, new CometFactory());
        }

        public void Start()
        {
            AddPlayer();
            AddEnemies(EntityTypes.Meteor, 10);
            AddEnemies(EntityTypes.Asteroid, 5);
            AddEnemies(EntityTypes.Comet, 3);
        }

        public void OnUpdate(float deltaTime)
        {
            _updateManager.OnUpdate(deltaTime);
        }

        public void OnFixedUpdate(float deltaTime)
        {
            _fixedUpdateManager.OnFixedUpdate(deltaTime);
        }

        private void AddPlayer()
        {
            var playerGameObject = ViewServices.Instance.Instantiate(Resources.Load<GameObject>(EntityTypes.Player.ToString()));
            var player = playerGameObject.GetComponent<PlayerView>();
            player.OnShoot += AddBullet;

            var playerData = Resources.Load<PlayerData>(EntityData.PlayerData.ToString());
            var playerController = new PlayerController(
                new PlayerModel(playerData),
                player
            );
            _updateManager.AddController(playerController);
            _fixedUpdateManager.AddController(playerController);
        }

        private void AddEnemies(EntityTypes enemyType, int count)
        {
            for (var i = 0; i < count; i++)
            {
                _updateManager.AddController(_enemyFactory.Create(enemyType));
            }
        }

        private void AddBullet(Transform t)
        {
            var bullet = ViewServices.Instance.Instantiate(Resources.Load<GameObject>(EntityTypes.Bullet.ToString()));
            bullet.transform.SetPositionAndRotation(t.position + t.forward, t.rotation);

            var bulletData = Resources.Load<BulletData>(EntityData.BulletData.ToString());
            _updateManager.AddController(new BulletController(
                new BulletModel(bulletData),
                bullet.GetComponent<Bullet>()
            ));
        }
    }
}