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

        private void AddPlayer()
        {
            var playerGameObject = ViewServices.Instance.Instantiate(Resources.Load<GameObject>(EntityTypes.Player.ToString()));
            var player = playerGameObject.GetComponent<PlayerView>();
            player.OnShoot += AddBullet;

            var playerData = Resources.Load<PlayerData>(EntityData.PlayerData.ToString());
            _updateManager.AddController(new PlayerController(
                new PlayerModel(playerData),
                player
            ));
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
            GameObject bullet;
            var rand = Random.Range(0.0f, 1.0f);

            if (rand > 0.5f)
            {
                bullet = ViewServices.Instance.Instantiate(Resources.Load<GameObject>(EntityTypes.Bullet.ToString()));
            }
            else
            {
                var builder = new GameObjectBuilder(PrimitiveType.Cube);
                bullet = builder.Name("BulletFromBuilder")
                    .Rigidbody(5.0f)
                    .Bullet();
            }

            var position = t.position;
            var rotation = t.rotation;
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            bullet.GetComponent<Rigidbody>().position = position;
            bullet.GetComponent<Rigidbody>().MoveRotation(rotation);

            var bulletData = Resources.Load<BulletData>(EntityData.BulletData.ToString());
            _updateManager.AddController(new BulletController(
                new BulletModel(bulletData),
                bullet.GetComponent<Bullet>()
            ));
        }
    }
}