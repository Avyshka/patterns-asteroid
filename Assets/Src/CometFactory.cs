using Asteroids.Enums;
using Asteroids.Interfaces;
using UnityEngine;

namespace Asteroids
{
    public sealed class CometFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Comet>(EnemyTypes.Comet.ToString()));
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}