using Asteroids.Enemies.Enums;
using Asteroids.Enemies.Interfaces;
using Asteroids.Enemies.Views;
using Asteroids.Pools.Interfaces;
using UnityEngine;

namespace Asteroids.Enemies.Factories
{
    public sealed class CometFactory : IEnemyFactory
    {
        private readonly IViewServices _viewServices;
        
        public CometFactory(IViewServices viewServices)
        {
            _viewServices = viewServices;
        }

        public GameObject Create(Health hp)
        {
            var enemy = _viewServices.Instantiate(Resources.Load<GameObject>(EnemyTypes.Comet.ToString()));
            enemy.GetComponent<Comet>().DependencyInjectHealth(hp);
            return enemy;
        }
    }
}