using System.Collections.Generic;
using Asteroids.Enemies.Controllers;
using Asteroids.Enemies.Factories;
using Asteroids.Enemies.Models;
using Asteroids.Enemies.Views;
using Asteroids.Interfaces;
using Asteroids.Players.Controllers;
using Asteroids.Players.Models;
using Asteroids.Players.Views;
using Asteroids.Pools;
using Asteroids.Pools.Interfaces;
using Asteroids.ScriptableObjects;
using Asteroids.Weapons.Controllers;
using Asteroids.Weapons.Models;
using Asteroids.Weapons.Views;
using UnityEngine;

namespace Asteroids
{
    public class GameContext : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private EnemyData meteorData;
        [SerializeField] private EnemyData asteroidData;
        [SerializeField] private EnemyData cometData;
        [SerializeField] private BulletData bulletData;

        private IViewServices _viewServices;
        private List<IUpdatable> _updatableObjects = new List<IUpdatable>();

        private void Shoot(Transform t)
        {
            var bullet = _viewServices.Instantiate(Resources.Load<GameObject>("Bullet"));
            var position = t.position;
            var rotation = t.rotation;
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            bullet.GetComponent<Rigidbody>().position = position;
            bullet.GetComponent<Rigidbody>().MoveRotation(rotation);

            _updatableObjects.Add(new BulletController(
                new BulletModel(bulletData),
                bullet.GetComponent<Bullet>()
            ));
        }

        private void Start()
        {
            _viewServices = new ViewServices();

            AddPlayer();

            AddMeteors(10);
            AddAsteroids(10);
            AddComets(10);
        }

        private void AddPlayer()
        {
            var playerGameObject = _viewServices.Instantiate(Resources.Load<GameObject>("Player"));
            var player = playerGameObject.GetComponent<PlayerView>();
            player.OnShoot += Shoot;

            _updatableObjects.Add(new PlayerController(
                new PlayerModel(playerData),
                player
            ));
        }

        private void AddMeteors(int count)
        {
            var meteorFactory = new MeteorFactory(_viewServices);
            for (var i = 0; i < count; i++)
            {
                _updatableObjects.Add(new EnemyController(
                    new EnemyModel(meteorData),
                    meteorFactory.Create().GetComponent<Meteor>()
                ));
            }
        }

        private void AddAsteroids(int count)
        {
            var asteroidFactory = new AsteroidFactory(_viewServices);
            for (var i = 0; i < count; i++)
            {
                _updatableObjects.Add(new EnemyController(
                    new EnemyModel(asteroidData),
                    asteroidFactory.Create().GetComponent<Asteroid>()
                ));
            }
        }

        private void AddComets(int count)
        {
            var cometFactory = new CometFactory(_viewServices);
            for (var i = 0; i < count; i++)
            {
                _updatableObjects.Add(new EnemyController(
                    new EnemyModel(cometData),
                    cometFactory.Create().GetComponent<Comet>()
                ));
            }
        }

        private void Update()
        {
            for (var i = _updatableObjects.Count - 1; i >= 0; i--)
            {
                var c = _updatableObjects[i];
                if (c.IsDead)
                {
                    _updatableObjects.Remove(c);
                    _viewServices.Destroy(c.View);
                }
                else
                {
                    c.OnUpdate(Time.deltaTime);
                }
            }
        }
    }
}