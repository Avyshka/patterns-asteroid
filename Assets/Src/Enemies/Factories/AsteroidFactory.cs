using Asteroids.Enemies.Enums;
using Asteroids.Enemies.Interfaces;
using Asteroids.Enemies.Views;
using Asteroids.Pools.Interfaces;
using UnityEngine;

namespace Asteroids.Enemies.Factories
{
    public sealed class AsteroidFactory : IEnemyFactory
    {
        private readonly IViewServices _viewServices;

        public AsteroidFactory(IViewServices viewServices)
        {
            _viewServices = viewServices;
        }

        public GameObject Create(Health hp)
        {
            var enemy = _viewServices.Instantiate(Resources.Load<GameObject>(EnemyTypes.Asteroid.ToString()));
            enemy.GetComponent<Asteroid>().DependencyInjectHealth(hp);
            return enemy;
        }
    }
}