using Asteroids.Enemies.Controllers;
using Asteroids.Enemies.Factories;
using Asteroids.Entities.Entities.Enemies.Observers;
using Asteroids.Entities.Entities.Players.Factories;
using Asteroids.Entities.Entities.Players.Upgraders;
using Asteroids.Entities.Entities.Weapons.Factories;
using Asteroids.Entities.Enums;
using Asteroids.Entities.Factories;
using Asteroids.Players.Controllers;
using Asteroids.Players.Views;
using Asteroids.UI;
using UnityEngine;

namespace Asteroids
{
    public class GameScene
    {
        private readonly UpdateManager _updateManager;
        private readonly FixedUpdateManager _fixedUpdateManager;
        private readonly ObserverDestroyedEnemies _observerDestroyedEnemies;
        private readonly EntityFactory _entityFactory;
        private readonly UserInterface _ui;

        private Upgrader _upgrader;

        public GameScene(UserInterface ui)
        {
            _ui = ui;

            _observerDestroyedEnemies = new ObserverDestroyedEnemies();
            _observerDestroyedEnemies.AddDestroyedEnemy += _ui.UpdateDestroyedEnemy;
            
            _updateManager = new UpdateManager(_observerDestroyedEnemies);
            _fixedUpdateManager = new FixedUpdateManager();

            _entityFactory = new EntityFactory();
            _entityFactory.AddFactory(EntityTypes.Meteor, new MeteorFactory());
            _entityFactory.AddFactory(EntityTypes.Asteroid, new AsteroidFactory());
            _entityFactory.AddFactory(EntityTypes.Comet, new CometFactory());
            _entityFactory.AddFactory(EntityTypes.Player, new PlayerFactory());
            _entityFactory.AddFactory(EntityTypes.Bullet, new BulletFactory());
        }

        public void Start()
        {
            var player = AddPlayer();
            AddPlayerUpgrader(player);
            AddEnemies(EntityTypes.Meteor, 10);
            AddEnemies(EntityTypes.Asteroid, 5);
            AddEnemies(EntityTypes.Comet, 3);
        }

        public void OnUpdate(float deltaTime)
        {
            _updateManager.OnUpdate(deltaTime);
            _ui.OnUpdate(deltaTime);
        }

        public void OnFixedUpdate(float deltaTime)
        {
            _fixedUpdateManager.OnFixedUpdate(deltaTime);
        }

        private PlayerView AddPlayer()
        {
            var updatableController = _entityFactory.Create(EntityTypes.Player);
            if (updatableController is PlayerController playerController)
            {
                playerController.AddBullet += AddBullet;
                _updateManager.AddController(playerController);
                _fixedUpdateManager.AddController(playerController);
                return playerController.View.GetComponent<PlayerView>();
            }

            return null;
        }

        private void AddPlayerUpgrader(PlayerView player)
        {
            if (player == null)
            {
                return;
            }

            _upgrader = new Upgrader(player);
            _upgrader.Add(new DamageUpgrader(player, 5));
            _upgrader.Add(new HealthUpgrader(player, 3));
        }

        private void AddEnemies(EntityTypes enemyType, int count)
        {
            for (var i = 0; i < count; i++)
            {
                if (_entityFactory.Create(enemyType) is EnemyController enemyController)
                {
                    enemyController.AddScores += _ui.UpdateScores;
                    _observerDestroyedEnemies.Add(enemyController);
                    _updateManager.AddController(enemyController);
                }
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