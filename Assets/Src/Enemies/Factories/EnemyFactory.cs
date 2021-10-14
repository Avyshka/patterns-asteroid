using System.Collections.Generic;
using Asteroids.Enemies.Controllers;
using Asteroids.Enemies.Enums;
using Asteroids.Enemies.Interfaces;

namespace Asteroids.Enemies.Factories
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly Dictionary<EnemyTypes, IEnemyFactory> _factories = new Dictionary<EnemyTypes, IEnemyFactory>();

        public void AddFactory(EnemyTypes key, IEnemyFactory factory)
        {
            _factories.Add(key, factory);
        }

        public void RemoveFactory(EnemyTypes key)
        {
            _factories.Remove(key);
        }

        public EnemyController Create(EnemyTypes key)
        {
            return _factories.TryGetValue(key, out var factory) ? factory.Create(key) : null;
        }
    }
}