using Asteroids.Enums;
using Asteroids.Interfaces;
using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>(EnemyTypes.Asteroid.ToString()));
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}