using Asteroids.Enemies.Factories;
using Asteroids.Entities.Entities.Players.Factories;
using Asteroids.Entities.Entities.Weapons.Factories;
using Asteroids.Entities.Enums;
using Asteroids.Entities.Factories;
using Asteroids.Players.Controllers;
using UnityEngine;

namespace Asteroids
{
    public class GameScene
    {
        private readonly UpdateManager _updateManager = new UpdateManager();
        private readonly FixedUpdateManager _fixedUpdateManager = new FixedUpdateManager();
        private readonly EntityFactory _entityFactory;

        public GameScene()
        {
            _entityFactory = new EntityFactory();
            _entityFactory.AddFactory(EntityTypes.Meteor, new MeteorFactory());
            _entityFactory.AddFactory(EntityTypes.Asteroid, new AsteroidFactory());
            _entityFactory.AddFactory(EntityTypes.Comet, new CometFactory());
            _entityFactory.AddFactory(EntityTypes.Player, new PlayerFactory());
            _entityFactory.AddFactory(EntityTypes.Bullet, new BulletFactory());
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
            var updatableController = _entityFactory.Create(EntityTypes.Player);
            if (updatableController is PlayerController playerController)
            {
                playerController.AddBullet += AddBullet;
                _updateManager.AddController(playerController);
                _fixedUpdateManager.AddController(playerController);
            }
        }

        private void AddEnemies(EntityTypes enemyType, int count)
        {
            for (var i = 0; i < count; i++)
            {
                _updateManager.AddController(_entityFactory.Create(enemyType));
            }
        }

        private void AddBullet(Transform transform)
        {
            var bulletController = _entityFactory.Create(EntityTypes.Bullet);
            bulletController.View.transform.SetPositionAndRotation(
                transform.position + transform.forward,
                transform.rotation
            );
            _updateManager.AddController(bulletController);
        }
    }
}