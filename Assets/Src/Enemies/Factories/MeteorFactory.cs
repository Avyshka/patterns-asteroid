using Asteroids.Enemies.Enums;
using Asteroids.Enemies.Interfaces;
using Asteroids.Pools.Interfaces;
using UnityEngine;

namespace Asteroids.Enemies.Factories
{
    public sealed class MeteorFactory : IEnemyFactory
    {
        private readonly IViewServices _viewServices;
        
        public MeteorFactory(IViewServices viewServices)
        {
            _viewServices = viewServices;
        }
        
        public GameObject Create()
        {
            var enemy = _viewServices.Instantiate(Resources.Load<GameObject>(EnemyTypes.Meteor.ToString()));
            return enemy;
        }
    }
}